using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivClassLibrary;
using System.Reflection;

namespace Client.Assemblies
{
    class Assembliesmod
    {  Assembly asm = Assembly.Load("PrivClassLibrary");
        ExtClass exts = new ExtClass("daw");
       public void Run()
        {
            exts.UseMe();
            Console.WriteLine("By  InstanceObj.GetType()");
            Type t1  = exts.GetType();
          MethodInfo[] miOft11 =   t1.GetMethods();
          foreach(var mi in miOft11)
            {
                Console.WriteLine(mi.ToString());
            }

          Type t2 =   typeof(ExtClass);
            Console.WriteLine("\n\nBy TypeOf(ClassName)");
            MethodInfo[] miOft12 = t1.GetMethods();
            foreach (var mi in miOft12)
            {
                Console.WriteLine(mi.Name);
            }

            Type t3 = Type.GetType("Assembliesmod.ExtClass", false, true);
            MethodInfo[] miOft13 = t1.GetMethods();
            Console.WriteLine("\n\nBy TypeOf(ClassName)");
            foreach (var mi in miOft13)
            {
                Console.WriteLine(mi.Name);
            }

        }

    }
}
