using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    partial class CoreCSPart2
    {
        struct MySampleStruct
        {
           public int a;
           int b;
           public String s;
        }
        
        private static void MethodAndParametersModifiers()
        {
            int inA = 0; // error int inA;
            int inB = 0; // error int inB;
            int inC;     // no error
            Console.WriteLine($"inA: {inA} inB: {inB} inC:-not assigned");
            RefOut1(inA, ref inB, out inC);
            Console.WriteLine($"inA: {inA} inB: {inB} inC: {inC}");
            RefOutParams(ref inB, out inC, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine($"inA: {inA} inB: {inB} inC: {inC}");
            MySampleStruct myS = new MySampleStruct();
            Console.WriteLine("MyStruct.a {0}  MyStruct.s {0}", myS.a, myS.s);
            ValueTypeParams(myS);
            Console.WriteLine("MyStruct.a {0}  MyStruct.s {0}", myS.a, myS.s);
           // NamedParams();

        }
        private static void RefOut1(int a, ref int refB, out int outC)
        {
            a = 3; outC = 2; refB = 1;
        }
        private static void RefOutParams(ref int refB, out int outC, params int[] par)
        {
            outC = 2; refB = 3;
            refB = par.Count();
        }
        private static void ValueTypeParams(MySampleStruct ms)
        {
            ms.a = 2;
            ms.s = "First";
        }

    }
}
