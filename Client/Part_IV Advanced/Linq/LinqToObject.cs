using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.Linq
{

    class HelperFct :IEqualityComparer<ExampleObject>
        {
        public bool Equals(ExampleObject x, ExampleObject y)
        {

            if ((x.Age.Equals(y.Age)) && (x.Name == y.Name) && (x.Salary == y.Salary) && (x.Surname == y.Surname)
                )
            {
                return true;
            }
            else
                return false;
        }

        public int GetHashCode(ExampleObject obj)
        {
            int hashNameCode = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashSurnameCode = obj.Surname == null ? 0 : obj.Surname.GetHashCode();
            return hashNameCode ^ hashSurnameCode;
        }
    }
    class ExampleObject
    {
        public string  Name { get; set; }
        public string Surname  { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

       
    }
    class LinqToObject
    {
        static List<ExampleObject> GetNewList(int listNr)
        {
            if (0 == listNr)
            {
                return new List<ExampleObject>()
            {
                new ExampleObject() { Name="Dawid",  Surname= "Stoga" , Age=32, Salary =2310m },
                new ExampleObject() { Name="Kasia",  Surname= "Kot" , Age=18, Salary =1200m },
                new ExampleObject() { Name="Hubert",  Surname= "Zarcik" , Age=54, Salary =8000m },
                new ExampleObject() { Name="Stefan",  Surname= "Jakubiec" , Age=26, Salary =1472m },
                new ExampleObject() { Name="Dawid",  Surname= "Sroka" , Age=33, Salary =2910m }
            };
            }
            else
            {
                return new List<ExampleObject>()
            {
                new ExampleObject() { Name="Dawid",  Surname= "Stoga" , Age=32, Salary =2310m },
                new ExampleObject() { Name="Andrzej",  Surname= "Kot" , Age=18, Salary =1200m },
                new ExampleObject() { Name="Hubert",  Surname= "Zarcik" , Age=54, Salary =8000m },
                new ExampleObject() { Name="Stefan",  Surname= "Jakubiec" , Age=26, Salary =1472m },
                new ExampleObject() { Name="Dawid",  Surname= "Sroka" , Age=33, Salary =2910m }
            };
            }
        }

       
        public static void CompareItems()
        {
            Console.WriteLine("Compare Items");
            List<ExampleObject> FirstData = GetNewList(0);
            List<ExampleObject> SecondData = GetNewList(1);

            var exceptRes  = FirstData.Except(SecondData,new HelperFct());
            var InterRes = FirstData.Intersect(SecondData, new HelperFct());
            var unionRes = FirstData.Union(SecondData, new HelperFct());
            var concatRes = FirstData.Concat(SecondData).Distinct(new HelperFct());
            Console.WriteLine("Except()");
            foreach (var res in exceptRes) Console.WriteLine($"name: {res.Name} surname: {res.Surname} age: {res.Age} salary: {res.Salary}");
            Console.WriteLine("Intersect()");
            foreach (var res in InterRes) Console.WriteLine($"name: {res.Name} surname: {res.Surname} age: {res.Age} salary: {res.Salary}");
            Console.WriteLine("Union()");
            foreach (var res in unionRes) Console.WriteLine($"name: {res.Name} surname: {res.Surname} age: {res.Age} salary: {res.Salary}");
            Console.WriteLine("Concat()");
            foreach (var res in concatRes) Console.WriteLine($"name: {res.Name} surname: {res.Surname} age: {res.Age} salary: {res.Salary}");

        }
        public  static void FromGeneric()
        {

             List<ExampleObject> exampleObjects  = GetNewList(0);
            var res1 = from x in exampleObjects where x.Salary > 2000 select x.Name;
            var res2 = exampleObjects.Select(x => x).Where(b=>b.Salary > 2100).Select(y=>y.Surname);
            var res3 = exampleObjects.Where(b => b.Age > 29).Select(x=> new { wiek = x.Age, nazwisko = x.Surname });

            foreach (var e in res1) Console.Write(e+ " " );
            Console.WriteLine();
            foreach (var e in res2) Console.Write(e + " ");
            Console.WriteLine();
            foreach (var e in res3) Console.Write(e.nazwisko + " ");
            Console.WriteLine();

        }
        public static void NonGeneric()
        {
            ArrayList al = new ArrayList() { "1", 1, 5, "daw", false };


          //  var res = from c in al where c == 1 select c;
            var res = from c in al.OfType<int>() where c == 1 select c;
            var alEnumerOfType = al.OfType<int>();
           // var alEnumerCast = al.Cast<int>();   //Error  -all object need to be able to cast to TResult!
          //  foreach(var i in alEnumerCast)
             //   Console.WriteLine(i);
            foreach (var i in alEnumerOfType)
                Console.WriteLine(i);

        }
    }
}
