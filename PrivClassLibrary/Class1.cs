using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivClassLibrary
{
    public class ExtClass
    {
        public int myProperty { get; set; }
        public List<int> MyList { get; set; } 
        public string extString { get; set; }
        public ExtClass(string s )
        {
            extString = s;
            Console.WriteLine(s);
        }
        public string ShowMessage(string msg)
        {
            
            return msg;
        }
        public void UseMe()
        {
          // Console.WriteLine("This is private Librasry: {0}", extString,System.Reflection.AssemblyName.GetAssemblyName(xx));
        }
    }
}
