using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    

  
    
    partial class CoreCSPart2
    {

        private static void NullableTypes()
        {
            int? i;
            int y;
            i = null;
            Nullable<int> inull = new Nullable<int>() ;
            y = i ?? 5;
            string h = i?.ToString() ?? "0";
            int? d = i?.GetHashCode() ?? 0;

            Console.WriteLine($"You {i?.GetHashCode() ?? 0} sent me {(i?.ToString()) ?? "0"} arguments.");
        }

    }
}
