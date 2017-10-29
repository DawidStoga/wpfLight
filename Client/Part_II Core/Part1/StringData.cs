using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    partial class CoreCSPart1
    {

        /// <summary>
        /// System.String Data
        /// </summary>
        private static void StringData()
        {
            Console.WriteLine("\n------------3.5  System.String Data------------\n ");
            string a = "da\"";           //String is reference Type but its methids are overriden to work in value manner
            int x = a.GetHashCode();
            Console.WriteLine($"At the beginning a  has = {a}  HashCode {a.GetHashCode()}");
            a = "daws";
            Console.WriteLine($"After changing the text a  has = {a} HashCode {a.GetHashCode()}");
            x = a.GetHashCode();  //Hash is int value
            string MyString = "TestString";
            int stringLenght = MyString.Length;



            string sentence = "the quick brown fox jumps over the lazy dog";
            // Split the string into individual words.
            string[] words = sentence.Split(' ');

            // Prepend each word to the beginning of the 
            // new sentence to reverse the word order.
            //extension Methods
            string reversed = words.Aggregate((workingSentence, next) =>
                                                  next + " " + workingSentence);

            bool AreAllLetter = MyString.All((next) => { return Char.IsLetter(next); });
            Console.WriteLine(AreAllLetter);

            MyString = "TestString2";
            AreAllLetter = MyString.All((next) => { return Char.IsLetter(next); });
            Console.WriteLine(AreAllLetter);


            var s = MyString.Any((next) =>
            {
                return Char.IsUpper(next);
            });

            IEnumerable<char> sGeneratedString = Enumerable.Repeat('a', 20);
            MyString = "WhoisWho";
            Console.WriteLine("Avg = {0:x}", (int)MyString.Average(next => (int)next));
            IEnumerable<int> ieInt = MyString.Cast<int>();  //cast to IEnumerable
            var sClonedString = MyString.Clone();
            Console.WriteLine($"sClonedString = {sClonedString.GetHashCode()}  mystr = {sClonedString.GetHashCode()}");

            Console.WriteLine("CompareTo " + MyString.CompareTo("WhoisWho"));
            var b = MyString.DefaultIfEmpty();

            Console.WriteLine("string.Compare  (of different text) result {0} ", string.Compare("ss", "dd"));
            // string.Format()

            foreach (char c in sGeneratedString)
            {
                Console.WriteLine(c);
            }


            //Works on the same instance.
            StringBuilder sb = new StringBuilder("First");
            sb.Append(5).AppendFormat("0:x", 2).Replace('i', 'y');
            Console.WriteLine(sb);
      
      
        }
    }
}
