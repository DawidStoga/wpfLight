using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.OOP
{
    class ExceptionHandling
    {
        private static void ExceptionHandlingMeth()
        {

            try
            {
                throw new ExceptionsH();
            }
            catch (ExceptionsH ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.Source);

            }
        }

        class ExceptionsH : System.Exception
        {
            public override IDictionary Data
            {
                get
                {
                    return base.Data;
                }
            }
            public override string Message
            {
                get
                {
                    return "ERROR DAWIDA";
                }
            }
        }
    }
}
