using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace Client.BaseLibrary
{
    public partial class IO
    {

        private static  readonly string workspace = "E:\\";
        public enum SerializeFormatter { Binary, Soap,Xml};
        public enum Category {
            [XmlEnum("Komedia")]
            Comedy,
            [XmlEnum("Dramat")]
            Drama,
            [XmlEnum("Horror")]
            Horror };


        [Serializable, XmlRoot(Namespace = "http://mycompanycom")]
        public class Movie : ITypeToSerialize
        {


            public string Title { get; set; }
            public string Director { get; set; }
            //  public string Label { get; set; }
            // public List<Actor> Actors { get; set; }  not collecion of generic type
            //   public List<string> Actors { get; set; }
            public string[] Actors { get; set; }
            public int Lenght { get; set; }
            private int Budget { get; set; } = 1000;

            [NonSerialized]
            public string NoSignificantData;


            [OnSerializing]
            public void OnSerializing(StreamingContext ctx)
            {
               Title =  Title.Insert(0, "DS_");
                
                Console.WriteLine("Before serializing  ctxState = {0}", ctx.State);
            }
            [OnSerialized]
             void ShowMessageAfterSer(StreamingContext ctx)    =>Console.WriteLine("After serializing");
            [OnDeserializing]
            void ShowMessageAfterDeSer(StreamingContext ctx)
            {
               
                Console.WriteLine("After serializing");
            }
            [OnDeserialized]
            void OnDeserialized(StreamingContext ctx)
            {
                Title  = Title.Remove(0, "DS_".Length);
              Console.WriteLine("After serializing");
            }
            public Movie()
            {

            }

        }
        [Serializable]   // Child class doesn't inherits the Serialze attribute
       public  class Drama:Movie
        {
            public string description;
            public string country;
            

        }
        [Serializable]
       public class Actor:ITypeToSerialize
       {
            [XmlAttribute]
            public string Name { get; set; }   //serialize the data as an XML attribute
            [XmlElement("Nazwisko")]
            public string Surname { get; set; }
            public string Role { get; set; }
            public Category PlayIn { get; set; }
        }



        public static void SavaData(string fileName, object objectGraph, SerializeFormatter formatter)
        {
            
            using (var fileStream = File.Open(workspace + fileName, FileMode.OpenOrCreate))
            {

                switch (formatter)
                {
                    case SerializeFormatter.Binary:

                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fileStream, objectGraph);

                        break;
                    case SerializeFormatter.Soap:

                        SoapFormatter sf = new SoapFormatter();
                        sf.Serialize(fileStream, objectGraph);
                        break;
                    case SerializeFormatter.Xml:
                        XmlSerializer xmlSerializer = new XmlSerializer(objectGraph.GetType());
                        xmlSerializer.Serialize(fileStream, objectGraph);
                        break;
                    default: break;
                }



            }
        }


        private static T RestoreData<T>(string fileName, SerializeFormatter formatter) where T: ITypeToSerialize
        {
            //T restoredObject = default(T);
            object restoredObject = null;
            using (var fileStream = File.Open(workspace + fileName, FileMode.OpenOrCreate) )
            {

               
                switch (formatter)
                {
                    case SerializeFormatter.Binary:

                        BinaryFormatter bf = new BinaryFormatter();
                        restoredObject = bf.Deserialize(fileStream);

                        break;
                    case SerializeFormatter.Soap:

                        SoapFormatter sf = new SoapFormatter();
                        restoredObject = sf.Deserialize(fileStream);
                        break;
                    case SerializeFormatter.Xml:
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        restoredObject = xmlSerializer.Deserialize(fileStream);

                        break;
                    default: break;
                }

            }
            return (T)restoredObject;
        }

       public  static void TestSerilaze()
        {
            SerializeObjects();
            FunWithAttributes();
            SerializeCollection();
            CustomSerialization();
         
        }

        [Serializable]
        class CustomClass : ISerializable
        {
            private string dataItemOne = "First data block";
            private string dataItemTwo = "More data";
            public CustomClass()
            {

            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("First_Item", dataItemOne.ToLower());
                info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
            }
            protected CustomClass(SerializationInfo si, StreamingContext ctx)
            {
                dataItemOne = si.GetString("First_Item").ToLower();
                dataItemTwo = si.GetString("dataItemTwo").ToLower();
            }
        }
        private static void CustomSerialization()
        {
            CustomClass cc = new CustomClass();
            SavaData("customSer.xml", cc, SerializeFormatter.Soap);




        }

        private static void SerializeCollection()
        {
            var Actors = new List<Actor>
            {
                new Actor(){ PlayIn = Category.Comedy,Name = "Nick", Surname= "Rud", Role = "Zombie"},
                new Actor(){ PlayIn = Category.Comedy,Name = "Paul", Surname= "Rogby", Role = "Ted"},
                new Actor(){ PlayIn = Category.Comedy,Name = "Jessica", Surname= "Witston", Role = "Julia"},
            };


            SavaData("Colection.xml", Actors, SerializeFormatter.Xml);
           // SavaData("ColectionSoap.xml", Actors, SerializeFormatter.Soap);
            SavaData("Colection.dat", Actors, SerializeFormatter.Binary);

        }

        public static void SerializeObjects()
        {


            Movie spiderMan = new Movie
            {
                Director = "Sam Raimi",
                Lenght = 98,
                Title = "Spider-Man",
                Actors = new[] { "Kirsten Dunst", "Tobey Maguire", "Willem Dafoe" }
                /*Actors = new List<string> { "Kirsten Dunst", "Tobey Maguire", "Willem Dafoe" }*/
                /* new Actor { Name = "Kirsten", Surname = "Dunst", Role = "Mary Jan"     },
                 new Actor { Name = "Tobey", Surname = "Maguire", Role = "Peter Parker" },
                 new Actor { Name = "Willem", Surname = "Dafoe", Role = "Norman Osborn" },
}*/
            };
            Drama batman = new Drama()
            {
                country = "US",
                description = "SomeDescription",
                Title = "Batman",
                Director = "Bill Gates",
                Lenght = 21
            };




            SavaData("SpiderManBinary.dat", spiderMan, SerializeFormatter.Binary);
            SavaData("batmanBinary.dat", batman, SerializeFormatter.Binary);


            SavaData("SpiderManSoap.xml", spiderMan, SerializeFormatter.Soap);
            SavaData("batmanSoap.xml", batman, SerializeFormatter.Soap);


            SavaData("SpiderManXml.xml", spiderMan, SerializeFormatter.Xml);
            SavaData("batmanXml.xml", batman, SerializeFormatter.Xml);


            var restoredBin = RestoreData<Movie>("SpiderManBinary.dat", SerializeFormatter.Binary);
            var restoredSoap = RestoreData<Movie>("SpiderManSoap.xml", SerializeFormatter.Soap);
            var restoredXml = RestoreData<Movie>("SpiderManXml.xml", SerializeFormatter.Xml);

            Console.WriteLine($"RestoredBin: {restoredBin.Title}");
            Console.WriteLine($"RestoredBin: {restoredSoap.Title}");
            Console.WriteLine($"RestoredBin: {restoredXml.Title}");
            /* SoapFormatter sp = new SoapFormatter();
             var fs1 = File.Open("E:\\SerialSoap1.txt", FileMode.OpenOrCreate);
             var fs2 = File.Open("E:\\SerialSoap2.txt", FileMode.OpenOrCreate);
             Console.WriteLine("Start serializing by SoapFormatter" );
             sp.Serialize(fs1, spiderMan);
             sp.Serialize(fs2, batman);
             fs1.Dispose();
             fs2.Dispose();

             BinaryFormatter bf = new BinaryFormatter();
             var fsBin1 = File.Open("E:\\SerialBinary1.txt", FileMode.OpenOrCreate);
             var fsBin2 = File.Open("E:\\SerialBinary2.txt", FileMode.OpenOrCreate);
             Console.WriteLine("Start serializing by SoapFormatter");
             bf.Serialize(fsBin1, spiderMan);
             bf.Serialize(fsBin2, batman);
             fsBin1.Dispose();
             fsBin2.Dispose();



             Type type = typeof(Movie);
             XmlSerializer xf = new XmlSerializer(type);
             var fsXml = File.Open("E:\\SerialXml1.txt", FileMode.OpenOrCreate);

             Console.WriteLine("Start serializing by XMLSerializer");
             xf.Serialize(fsXml, spiderMan);

             xf = new XmlSerializer(typeof(Drama));
             fsXml = File.Open("E:\\SerialXml2.txt", FileMode.OpenOrCreate);
             xf.Serialize(fsXml, batman);
             fsXml.Dispose();*/

        }
        public static void FunWithAttributes()
        {
            Actor actor = new Actor
            {
                Name = "John",
                Role = "Mathiew",
                Surname = "Trump",
                PlayIn = Category.Comedy
            };

            SavaData("Actor.xml", actor, SerializeFormatter.Xml);
            var act =  RestoreData<Actor>("Actor.xml", SerializeFormatter.Xml);

            Console.WriteLine($"Name={act.Name}  Rolse {act.Role} Surname = {act.Surname} PlayIn= {act.PlayIn} " );
        }
    





















        public static void RunSerialize()
            {

            }
        [Serializable, XmlRoot(Namespace = "Dawid", DataType = "FG")]
        public class ToSerialize
        {
            private string Name { get; set; }
            public int age;
            public void Display()
            {
                Console.WriteLine(Name + " is  " + age + "years old");
            }
            public ToSerialize()
            {

            }
            public ToSerialize(string name, int age)
            {
                this.Name = name;
                this.age = age;

            }
            public ToSerialize(int age)
            {
                this.Name = "He";
                this.age = age;
            }
        }


        public class SerializeIO
        {
            static ToSerialize person = new ToSerialize("Dawid", 32);
            static ToSerialize person2 = new ToSerialize("Dawid", 32);

            public static void SerializeToXML()
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToSerialize));
                using (Stream fStream = new FileStream("D:\\dirInfo\\serial.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fStream, person);
                }
            }
            public static void SerializeTest()
            {

                //     FileStream fs = File.Create("D:\\dirInfo\\serial.dat");
                FileStream fs = new FileStream("D:\\dirInfo\\serial.dat", FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                FormatterAssemblyStyle fas = bf.AssemblyFormat;
                Console.WriteLine(fas.ToString());

                bf.Serialize(fs, person);
                fs.Seek(0, SeekOrigin.Begin);
                ToSerialize ts = (ToSerialize)bf.Deserialize(fs);
                Console.WriteLine(ts.age);



                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, ts);
                fs.Close();

            }



        }
    }

    internal interface ITypeToSerialize
    {
    }
}
