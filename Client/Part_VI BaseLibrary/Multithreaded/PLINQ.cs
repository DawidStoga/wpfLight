using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Client.BaseLibrary
{
    partial class Multithreaded
    {
        
         public static void TestPlinq()
        {
            var Numbers = Enumerable.Range(1, 1000);

            var result = from x in Numbers.AsParallel()
                         where x > 500
                         select (new
                         {
                             id = x,
                             name = x.ToString()
                         });
        foreach(var c in result)
            {
                Console.Write(c.id + "  " );
            }

            result.ForAll(n =>

                Console.WriteLine(n.id));
            
        }
    }
}
