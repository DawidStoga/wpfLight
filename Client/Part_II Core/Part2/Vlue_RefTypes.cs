using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    

  
    
    partial class CoreCSPart2
    {
        static private void ValueRefTypes()
        {
            List<int> myList = new List<int>() { 1, 2, 3 };
            Console.WriteLine("Value:" + myList.First() + " HC: " + myList.GetHashCode());
            ValueArgs(myList);
            Console.WriteLine("Value:" + myList.First() + " HC: " + myList.GetHashCode());
            RefArgs(ref myList);
            Console.WriteLine("Value:" + myList.First() + " HC: " + myList.GetHashCode());

        }
        static private void RefArgs(ref List<int> arg) { List<int> intList = new List<int>() { 11, 12, 13 }; arg[0] = 4; arg = intList; }
        static private void ValueArgs(List<int> arg) { List<int> intList = new List<int>() { 11, 12, 13 }; arg[0] = 8; arg = intList; }


    }
}
