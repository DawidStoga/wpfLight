using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
   
    partial class CoreCSPart2
    {
    
        private static void Arrays()
        {
            int[] IntArray1 = { 1, 2, 3 };
            int[] IntArray2 = new int[] { 4, 5, 6 };
            int[] IntArray3 = new int[4];
            int[] IntArray4 = new int[4] { 6, 7, 8, 9 };
            int[] IntArray5 = IntArray4;
            var IntArray6 = new int[] { 10, 11, 12 };
            foreach (var i in IntArray1) Console.Write(" " + i); Console.WriteLine();
            foreach (var i in IntArray2) Console.Write(" " + i); Console.WriteLine();
            foreach (var i in IntArray3) Console.Write(" " + i); Console.WriteLine();
            foreach (var i in IntArray4) Console.Write(" " + i); Console.WriteLine();
            foreach (var i in IntArray5) Console.Write(" " + i); Console.WriteLine();
            foreach (var i in IntArray6) Console.Write(" " + i); Console.WriteLine();
            Console.WriteLine(IntArray1.GetType().ToString());
            var t = IntArray1.Select((x, y) => { return x * 20; });  //LINQ
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }

            int[,] intDimArray = new int[,] { { 1, 2 }, { 3, 4 }, { 4, 5 } };
            int qy = intDimArray.Rank;
            int rt = intDimArray[0, 1];
            var outInt = (from int item in intDimArray
                          select item);
            Console.WriteLine("\nfrom int item in intDimArray");
            foreach (var item in outInt)
            {
                Console.Write(item);
            }
            Console.WriteLine("\nfrom item in intDimArray.Cast<int>()");
            var outInt2 = from item in intDimArray.Cast<int>() select item;
            foreach (var item in outInt2)
            {
                Console.Write(item);
            }
            Console.WriteLine("\nfrom item in intDimArray.OfType<int>()");
            var outInt3 = from item in intDimArray.OfType<int>() select item;
            foreach (var item in outInt3)
            {
                Console.Write(item);
            }

            var readOnlyArray = Array.AsReadOnly(IntArray1);
            //Error readOnlyArray[2] = 3;
            int index = Array.BinarySearch(IntArray4, 7); //return 1;

            IntArray4[0] = 15;
            Console.WriteLine("\n[0]: " + IntArray4[0]);
            Array.Sort(IntArray4);
            Console.WriteLine("[0]: " + IntArray4[0]);

        }
 

    }
}
