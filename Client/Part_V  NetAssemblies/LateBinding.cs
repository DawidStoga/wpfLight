using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client.Assemblies
{
    class LateBinding
    {


       // Environment.GetLogicalDrives();
        public static  void Run()
        {
         
            Console.WriteLine("***** Fun with Late Binding *****");
            Assembly asm = null;
            try
            {
                asm = Assembly.Load("PrivClassLibrary");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if(asm!=null)
            {
                CreateUsingLateBinding(asm);
            }

        }


        private static void  CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type myExtClass = asm.GetType("PrivClassLibrary.ExtClass");


               //Reflection  + lateBinding - long solution
                object extObj = Activator.CreateInstance(myExtClass, new object[] { "dawid" });
                Console.WriteLine("Created a {0} using late binding!", extObj);
                MethodInfo methInfo = myExtClass.GetMethod("ShowMessage");
                var  sRetun = methInfo.Invoke(extObj, new object[] { "I invokded method by reflection" });
                Console.WriteLine(sRetun);

                // 2'nd way    Dunamic keyword
                 dynamic obj = Activator.CreateInstance(myExtClass, new object[] { "dawid" });
                sRetun =  obj.ShowMessage("..Now I invokded method by dynamic");
                Console.WriteLine(sRetun);


           


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
