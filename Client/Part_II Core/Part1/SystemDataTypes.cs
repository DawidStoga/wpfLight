using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    partial class CoreCSPart1
    {
        private static void SystemDataTypes()
        {
            Console.WriteLine("\n------------3.4  System Data Types------------ \n");

            Console.WriteLine("2.5  " + (2.5).GetType().ToString());
            Console.WriteLine("2.5M  " + (2.5M).GetType().ToString());
            Console.WriteLine("2.5F  " + (2.5F).GetType().ToString());
            int num = new int();  // is struct in fact  - new set to default (0)
            int num2 = 2;
            Console.WriteLine($"Num: {num} Num2: {num2}");
            num2 = 0; //reasigned
            Console.WriteLine("Num.Compare(Num2) " + num.CompareTo(num2));  //Methods derives from Object
            Console.WriteLine("Num.Equals(Num2) " + num.Equals(num2));
            Console.WriteLine(double.Epsilon); ;
            Console.WriteLine(bool.FalseString);
            char.IsDigit('3');
            char.IsDigit("dawid", 2);
            bool isFalse;
            bool.TryParse("false", out isFalse);
            
            Console.WriteLine(isFalse.ToString());


            DateTime dt = new DateTime(2006, 9, 24, new GregorianCalendar()); // many overriden methods
            Console.WriteLine(dt);
            Console.WriteLine((dt.Add(new TimeSpan(0, 1, 2)).ToString()));
            TimeSpan ts = new TimeSpan(1, 1, 1);
            Console.WriteLine(ts);
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 0, 12)));

            //system.Numeric
            //BigIneger bigNum = 0;

        }
    }
}
