using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.advLangFeatures
{

    class Indexer
    {
        public List<int> ListaIn { get; set; }
        public Indexer()
        {
            ListaIn = new List<int>() { 1, 5, 3, 6, 4, 5, 6 };

        }
        public int this[int index] { get { return ListaIn[index]; } }
        public int this[string index] { get { return ListaIn[index.Length]; } }
        public void TestIndex()
        {
            Console.WriteLine("\n  Indexer - this[0] {0}",this[0]);
            Console.WriteLine("\n  Indexer - this[\"daw\"] {0}", this["daw"]);
        }

    }
}
