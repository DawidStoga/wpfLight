using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    

    public class CnamedArgTest
    {
        public int Arga { get; set; }
        public int ArgB { get; set; }

        public CnamedArgTest(int argument )
        {
            Arga = argument;

        }
        public void tets(string g )
        {
            Console.WriteLine(g);
        }
    }
    partial class CoreCSPart2
    {
        struct MyStruct
        {
            public int a;
           int b;
           public String s;

        }
      
        
        private static void NameParamsPre(MyStruct ms = new MyStruct())
        {
            CnamedArgTest ca = new CnamedArgTest(argument: 2) { Arga = 1 };
            ca.tets("d");
            ca.tets(g: "dd");
        }
        private static void NamedParams(MyStruct ms = default(MyStruct), int b = 2)
        {
            Console.WriteLine($"Named args  ms.a: {ms.a } b: {b} ");
        }
   


       
       
        private static void ClassType()
        {
            MyClass ct = new MyClass(3);
            Console.WriteLine("Property " + ct.MyProperty + " " + ct.MyStringProp + " " + ct.myListProp.ToString());

        }
        class MyClass
        {
            public int MyProperty { get; set; }
            public string MyStringProp { get; set; }
            public List<int> myListProp;

            public static float myStaticField = 0.04f;
            public static void StatiMethod()
            {
                Console.WriteLine("STATIC METHOD");
            }
            public static int MyStaticProp { get; set; }
            static MyClass()
            {
                myStaticField = 2;
                StatiMethod();
            }

            public MyClass()
            {
                Console.WriteLine("ctor()");
                //foreach (var i in myListProp) Console.WriteLine(i);

            }

            public MyClass(int x, int y = 9) : this(x)
            {
                Console.WriteLine("arg1 {0}  arg2 {1}", x, y);
            }

            private MyClass(int x) : this()
            {
                Console.WriteLine("ctor(x)");
                myListProp = new List<int>((Enumerable.Range(1, x)));
                foreach (var i in myListProp) Console.WriteLine(i);

            }
            public void MyMethod(int arg)
            {

            }

        }

    }
}
