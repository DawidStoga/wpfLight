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


        private static void Decision_Constructs()
        {
            Console.WriteLine("------------.8  Decision Constructs------------");
            int a = 1;
            int b = 1;
            int c = 1;
            if (2 == ++a || 2 == b++ || 2 == c++)
            {
                // IF  a = 2 b = 1 c = 1
                Console.WriteLine($" IF   a ={a} b= {b} c = {c} ");
            }
            else
            {
                Console.WriteLine($" ELSE a ={a} b= {b} c = {c} ");
            }

            a = 1;
            b = 1;
            c = 1;
            if (2 == a++ || 2 == b++ || 2 == ++c)
            {
                // IF a = 2 b = 2 c = 
                Console.WriteLine($" IF   a ={a} b= {b} c = {c} ");
            }
            else
            {
                Console.WriteLine($" ELSE a ={a} b= {b} c = {c} ");
            }

            var ienum = Enumerable.Range(1, 7);



            foreach (var s in MyIterator())
                Console.WriteLine(s);

            switch (a)
            {
                case 1: Console.WriteLine(1); break;

                case 2: Console.WriteLine(2); break;
                default: break;
            }


        }
    
        /// <summary>
        /// Iterators
        /// </summary>
        /// <returns></returns>
        protected static IEnumerable<int> MyIterator()
        {

            var IntConrainer = Enumerable.Range(1, 12);
            foreach (var nr in IntConrainer)
            {
                var i = nr.GetHashCode();

                yield return i;
            }

        }
    }
}
