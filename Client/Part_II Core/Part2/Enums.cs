using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    enum En { A = 256, B, C };

    enum EnByte : byte { A = 1, B, C }



    partial class CoreCSPart2
    {



        private static void Enums()
        {
            En en = En.A;
            Type t1, t2, t3;
            t1 = Enum.GetUnderlyingType(en.GetType());
            t2 = Enum.GetUnderlyingType(typeof(En));
            t3 = Enum.GetUnderlyingType(typeof(EnByte));
            Console.WriteLine("Enum types: \n en.GetType {0}\nEnum.GetUnderlyingType(en.GetType() {1} \nEnum.GetUnderlyingType(typeof(En) {2} \nEnum.GetUnderlyingType(typeof(EnByte) {3} ", en.GetType(), t1, t2, t3);
            Console.WriteLine("emp is a {0} value {1} {2}.", en.ToString(), (int)en, Enum.GetValues(typeof(En)).ToString());
            Console.WriteLine("value of en.A {0}", Enum.Format(typeof(En), En.C, "d"));
            Console.WriteLine("value of en.A {0}", Enum.Format(typeof(En), En.C, "f"));
            Console.WriteLine("value of en.A {0}", Enum.Format(typeof(En), En.C, "x"));
        }

    }
}
