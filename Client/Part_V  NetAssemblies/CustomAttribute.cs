using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Assemblies
{

    class FunWithAttributes
    {
    public static void  Run()
    {
        Test test = new Test("my message" );

            Type t = typeof(Test);
            object[] customAttr = t.GetCustomAttributes(false);
            foreach(CustomAttribute a in customAttr)
            {
                Console.WriteLine("\n {0}", a.MyProperty);
                a.RunSth();
            }
    }
    }
   
    class CustomAttribute:Attribute
    {
        public int MyProperty { get; set; }
        public CustomAttribute(string mess = "nikt")
        {
            MyProperty = mess.Length;
            Console.WriteLine("mess");
        }
        public void  RunSth()
        {
            Console.WriteLine("mess");
        }
    }

    [Custom(mess:"dawid")]
    class Test
    {

        [Custom]
        public Test(string message)
        {

        }
    }
}
