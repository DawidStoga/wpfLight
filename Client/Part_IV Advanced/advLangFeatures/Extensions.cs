using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.advLangFeatures
{
    static class MyExtensions
    {
        public static void WriteWithColor(this String str, ConsoleColor color)
        {
            ConsoleColor savec = Console.BackgroundColor;
            Console.BackgroundColor = color;
            Console.WriteLine(str);
            Console.BackgroundColor = savec;

        }
        public static void ExtMet(this TestOperators ext, ConsoleColor color)
        {
            ConsoleColor savec = Console.BackgroundColor;
            Console.BackgroundColor = color;
       
            ext.Test();
            Console.BackgroundColor = savec;
        }
        public static void ExtMet(this IEnumerable<int> ext, ConsoleColor color)
        {
            ConsoleColor savec = Console.BackgroundColor;
            Console.BackgroundColor = color;

            ext.Average();
            Console.BackgroundColor = savec;
        }



    }
}
