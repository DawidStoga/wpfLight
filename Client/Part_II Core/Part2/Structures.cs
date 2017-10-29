using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    

  
    
    partial class CoreCSPart2
    {
        struct MyTestStructe   //May contain value and reference Type
        {
            public int iFieldA;
            int iFieldB;
            public String sSomeString;
        }

        struct Point
        {

            public int a;
            public int b;
            public List<int> l;
            public string g;
            /* public  Point(int r)  // custom ctrol - each element must be assign!!
               {
                   b = 0;
                   g = "s";
                   a = b;
               }*/
            public int Meth1_ADD(int ina, int inb)
            {
                // a = ina;
                // l = new List<int>();
                // b = inb;
                Console.WriteLine(g);
                return a + b;// + l.Capacity;
            }
            public void Cout(string s)
            {
                Console.WriteLine($"{s} a={this.a}, b={this.b} c = {this.l.GetHashCode()}");
            }


        }
        private static void Structures()
        {
            Point pt = new Point(); // assign each field or use new key or custom contr.
            Point pt2;

            Console.WriteLine(pt.Meth1_ADD(2, 3));
            //error  - unassigned   Console.WriteLine(pt2.Meth1_ADD(2, 3));
            pt2.a = 2;
            pt2.b = 3;
            pt2.g = "2";
            pt2.l = new List<int>();
            pt.l = new List<int>() { 1, 2, 3 };
            Console.WriteLine(pt2.Meth1_ADD(2, 3));
            pt.Cout("pt");
            pt2.Cout("pt2");
            pt = pt2;
            pt.Cout("pt");
            pt2.l = new List<int>() { 2, 3, 4 };
            pt.Cout("pt");

        }

    }
}
