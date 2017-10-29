using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.OOP
{


    class ClassComparable : IComparable
    {
        public string Name { get; set; }
        public ClassComparable(string s ="X")
        {
            Name = s;
        }
        public int CompareTo(object obj)
        {
            var temp = obj as ClassComparable;
            if (temp != null)
             //   return (this.Name.Length > temp.Name.Length ? 1 : 0);
            return (this.Name.Length.CompareTo(temp.Name.Length));
            else
                return 0;
        }
    }


    class NamingComparer : IComparer<ClassComparable>
    {
        public int Compare(ClassComparable x, ClassComparable y)
        {
           return string.Compare(x.Name, y.Name);
            
        }
    }
}
