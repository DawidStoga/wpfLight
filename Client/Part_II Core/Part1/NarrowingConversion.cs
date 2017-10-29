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
        private static void NarrowingConversion()
        {
            Console.WriteLine("\n------------3.6  Narrowing and Widening Conversion------------\n");
            byte a = 210;
            byte b = 60;
            byte c = (byte)(a + b);
            Console.WriteLine(c);

            try
            {
                byte sum = checked((byte)(a + b));
                Console.WriteLine(sum);
            }
            catch (OverflowException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
