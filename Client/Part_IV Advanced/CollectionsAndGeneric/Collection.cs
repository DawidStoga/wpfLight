using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.CollectionsAndGeneric
{
    class Collections<Y> where Y:IEnumerable, new()
    {
        struct Point<T>
        {
            public Point(T xVal, T yVal)
                {
                x = xVal;
                y = default(T);
                }
            public T x { get; set; }
            public T y { get; set; }

            public void Display()
            {
                Console.WriteLine($"X {x} Y {y} ");
            }
        }
       
        ArrayList arrayList;
        BitArray  bitArray;
        Hashtable hashTable;
        Queue queue;
        SortedList sortedList;
        Stack stack;

        public Collections()
        {
           arrayList = new ArrayList(3){ 1,"5", false};
           bitArray = new BitArray(new[] { false, false, true }); //bool[]
            hashTable = new Hashtable(4); //capacity
            queue = new Queue(10, 1.0f);
            sortedList = new SortedList(10);
            stack = new Stack(10);

        }

       public void TestCollection()
        {
            var OnlyInt = arrayList.OfType<int>();
            bitArray.Not();
            sortedList.Add("bawid", "astoga");
            sortedList.Add("cagda", "bgaworska");
            sortedList.Add("auba", "cstoga");
            foreach (var t in sortedList)
                Console.WriteLine(((DictionaryEntry)t).Key);
            Console.WriteLine(bitArray.ToString());
            foreach (var i in OnlyInt)
            {
                Console.WriteLine(i);
            }
          
        }

       public void TestGenericCollecion()
        {
            Dictionary<string, int> genDict = new Dictionary<string, int>();
            genDict.Add("daw", 2);
            genDict.Add("kub", 23);

            LinkedList<int> genLinkedList = new LinkedList<int>(Enumerable.Range(100, 20));

            List<string> genList = new List<string>();
            List<string> genList2 = new List<string>() { "daw", "kr", "ssd" };
            List<string> genList4 = new List<string> { "daw", "kr", "ssd" };
            List<string> genList5= new List<string>(3) { "daw", "kr", "ssd" };

            genList.Add("dawid");
            Console.WriteLine(genList.TrueForAll((x) => { return x.Length > 3; }).ToString());
            genList.Add("KU");
            Console.WriteLine(genList.TrueForAll((x) => { return x.Length > 3; }).ToString());

            foreach (var n in genLinkedList)
            {
                n.ToString();
            }

            ObservableCollection<String> obsString = new ObservableCollection<string>(genList4);
            obsString.CollectionChanged += ObsString_CollectionChanged;
            obsString.Add("New object");
            ReadOnlyCollection<string> rd = new ReadOnlyCollection<string>(genList5);
       //     ReadOnlyObservableCollection<string> roObervableCol = new ReadOnlyObservableCollection<string>(genList5);
          




        }


        public void GenMethod<T>(T input) where T:ICollection
        {
            foreach(var i in input)
            {
                Console.WriteLine(i);
            }

            Point<int> myPoint = new Point<int>(2, 5);
            myPoint.Display();
        }
        private void ObsString_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Change!!!" + e.NewItems[0]);
        }
    }
    
}
