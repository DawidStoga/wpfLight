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

        internal static void ConsoleClass()
        {
            Console.WriteLine("\n------------3.3  System.Console Class ------------\n");

            //Provides culture-spexific information for formating and parsing numerical valus
            NumberFormatInfo myInv = NumberFormatInfo.InvariantInfo;

            int IntValue = 99999;

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "FIRST APP";
            Console.Beep(2000, 800);
            Console.BufferHeight = 1000;
            Console.BufferWidth = 2000;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CancelKeyPress += (s, ev) =>
            {
                Console.WriteLine(ev.SpecialKey.ToString());
                Console.ReadLine();
            };
            // numerical value formating
            Console.WriteLine($@"
                -c or C Currncy : {IntValue.ToString("C", System.Globalization.CultureInfo.CreateSpecificCulture("pl-PL"))};
                -d or D Decimal : {IntValue:d}
                -e or E Exponen : {IntValue:e}
                -f or F Fixed-P : {IntValue:f}
                -g or G General : {IntValue:g}
                -n or N Basic   : {IntValue:n}
                -x or X Hex :     {IntValue:x}
                -p or P Hex :     {IntValue:p}
                ");
            Console.WriteLine("-c or C Decimal:{0:c}", IntValue);
            // numerical value formating using String Format
            Console.WriteLine(string.Format("-c or C Decimal:{0:c}", IntValue));
            Console.WriteLine(string.Format("-d or D Decimal:{0,1:d}", IntValue));
            Console.WriteLine(string.Format("-d or D Decimal:{0,5:d}", IntValue));
            Console.WriteLine(string.Format("0,10 right alignment: :{0,10:d}", IntValue));
            Console.WriteLine("0,10 right alignment: :|{0,10:d} | left alignment: :{0,-10:d}  |", IntValue);
            Console.WriteLine(string.Format("-d or D Decimal:{0,10}", IntValue));
            Console.WriteLine(string.Format("-d or D Decimal:{0,15:D10}", IntValue));
            Console.WriteLine(string.Format("-d or D Decimal:{0,-5:d}", IntValue));
            Console.WriteLine(string.Format("-d or D Decimal:{0,-10:d}", IntValue));

            int value = 123456;
            Console.WriteLine(value.ToString("[##-##-##]"));
            Console.WriteLine(String.Format("{0:[##-##-##]}", value));
            // Displays [12-34-56]

            DateTime dt = new DateTime(2016, 03, 25);
            Console.WriteLine("{0:d}", dt);
            Console.WriteLine("{0:D}", dt);
            Console.WriteLine(dt.ToString("D", CultureInfo.CreateSpecificCulture("fr-BE")));
            Console.WriteLine("{0:g}", dt);

            /*
            -c or C Currncy : 99 999,00 zł;
            -d or D Decimal : 2
            -e or E Exponen : 9,999900e+004
            -f or F Fixed-P : 99999,00
            -g or G General : 99999
            -n or N Basic   : 99 999,00
            -x or X Hex :     1869f
            -p or P Hex :     9 999 900,00%

-c or C Decimal:99 999,00 zł
-c or C Decimal:99 999,00 zł
-d or D Decimal:99999
-d or D Decimal:99999
0,10 right alignment: :     99999
0,10 right alignment: :|     99999 | left alignment: :99999       |
-d or D Decimal:     99999
-d or D Decimal:     0000099999
-d or D Decimal:99999
-d or D Decimal:99999
[12-34-56]
[12-34-56]
2016-03-25
25 marca 2016
vendredi 25 mars 2016
2016-03-25 00:00*/
        }
    }
}
