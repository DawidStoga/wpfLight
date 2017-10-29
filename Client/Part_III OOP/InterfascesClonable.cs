using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Client.OOP
{

     public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T origin)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, origin);
                ms.Position = 0;
                return (T)bf.Deserialize(ms);
            }
        }
    }

    [Serializable]
    class ClassClonable : ICloneable
    {
        int field;
        string sProp { get; set; }
        AirPlanes ap= null;
        public ClassClonable()
        {
            field = 55;
            sProp = "xyx";
            ap = new AirPlanes { EnginesNr = 3 };
        }
        public void ChangeData()
        {
            field = 98;
            sProp = "ijk";
            ap = new AirPlanes { EnginesNr = 78 };
        }
        public void ShowData()
        {
            Console.WriteLine($"field: {field} sProp: {sProp}  AirPlane  eng: {ap.EnginesNr}");
        }
        public object Clone()
        {
            ClassClonable newClass = this.MemberwiseClone() as ClassClonable;
            newClass.ap = this.ap;
            return newClass;
        }
    }
}
