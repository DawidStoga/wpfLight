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

        /// <summary>
        /// Casting. Conversion
        /// </summary>
        /// <summary>
        /// VAR keyword
        /// </summary>
        private static void ImplicitlyTypes()
        {
            Console.WriteLine("\n------------3.7  ImplicitlyTypes------------\n");
            var implicitlyTyepeLocal = "MyLocalString";
            // Error implicitlyTyepeLocal = 2;

            Console.WriteLine(InternalImplicitlyTypes(implicitlyTyepeLocal));
        }


        private static string InternalImplicitlyTypes(/*var*/
        string implicitlyTyepeLocal)
        {
            var localVar = "StringVAR";

            Console.WriteLine(localVar.GetType().ToString());
            var ExampleIe = Enumerable.Range(1, 20);

            var LinqOut = from x in ExampleIe where x > 10 select x;

            foreach (var liczna in ExampleIe)
                Console.Write("{0,2}, ", liczna);
            Console.WriteLine();
            foreach (var liczna in LinqOut)
                Console.Write("{0}, ", liczna);
            return localVar;
        }
    }
}
