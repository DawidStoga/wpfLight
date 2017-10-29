using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    partial class CoreCSPart1
    {
        [Flags]
        public enum Examples
        {
            None=0,
            Enviroment,
            ConsoleClass,
            SystemDataTypes,
            StringData,
            NarrowingConversion,
            ImplicitlyTypes,
            Decision_Constructs
          }

        public static void RunExamples(Examples ex)
        {


            Console.WriteLine("***************CORE PROGRAMMING********************************");
            if ((ex & Examples.Enviroment)          == Examples.Enviroment)          Enviroment();
            if ((ex & Examples.ConsoleClass)        == Examples.ConsoleClass)        ConsoleClass();
            if ((ex & Examples.SystemDataTypes)     == Examples.SystemDataTypes)     SystemDataTypes();
            if ((ex & Examples.StringData)          == Examples.StringData)          StringData();
            if ((ex & Examples.NarrowingConversion) == Examples.NarrowingConversion) NarrowingConversion();
            if ((ex & Examples.ImplicitlyTypes)     == Examples.ImplicitlyTypes)     ImplicitlyTypes();
            if ((ex & Examples.Decision_Constructs) == Examples.Decision_Constructs) Decision_Constructs();
        }
    }
}
