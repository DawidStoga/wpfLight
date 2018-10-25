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

        public static void CompareStrings()
        {
            var individualAddrress = new Address
            {
                City = "Wroclaw",
                Country = "Poland",
                Line1 = "Gdynska",
                Postcode = "25-545"
            };

            var CompanyAddress = new Address
            {
                City = "Wroclaw",
                Country = "poland",
                Line1 = "ul. gdynska",
                Postcode = "25-545"
            };



            Console.WriteLine("individualAddrress == CompanyAddress      {0}", individualAddrress == CompanyAddress);

            var t  = ToNormalAddressFormat("OFC ST , dsaas,ewrw");


        }


        public static string Substitute(string s)
        {
            var abbrevs = new Dictionary<string, string>();
            abbrevs.Add("OFC", "OFFICE");
            abbrevs.Add("ST", "STREET");
            abbrevs.Add("ST.", "STREET");
            if (abbrevs.ContainsKey(s)) return abbrevs[s];

            // or use :
           // if (abbrevs.TryGetValue(s, out var abbr)) return abbr;

            return (s);
        }

        public static string ToNormalAddressFormat(string address)
        {
            return address.Split(' ').ToList().Select(Substitute).Aggregate((x, y) => x + y);
        }

        class Address
        {
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
            public string Line4 { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Postcode { get; set; }
        }

    }
}
