using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.OOP
{
    delegate int MyDelegate(int x);
    interface IMachine
    {
        int machinename { get; set; }
    }
    interface IAirCraft:IMachine
    {
      int EnginesNr { get; set; }
        //  int speed;   Error -> cannot contain field

        //delegate int MyDelegate(int x);  Error - > cannot contain delegate

        event MyDelegate myEvent;
        void Landing();
        string this[int number] { get; set; }

    }

   
    class Interfaces
    {
        
       
        public static void Run()
        {
            AirPlanes ap= new AirPlanes();
             Console.WriteLine( ap[5]);
            if(ap is IAirCraft)
            {
                Console.WriteLine("Ap is IAirCraft");
            }
           
            IAirCraft airCraft = ap as IAirCraft;

            ap = airCraft as AirPlanes;
            ap = (AirPlanes)airCraft;

            AirPlanes ab = ap as AirPlanes;
            AirPlanes ab2 = airCraft as AirPlanes;
            ICloneable icl = airCraft as ICloneable;
            if(icl != null)
             {
                Console.WriteLine("IClonable");
             }
            else
            {
                Console.WriteLine("NOT!");
            }


            ClassEnumerable ce = new ClassEnumerable();
            foreach(var t in ce)
            {
                Console.WriteLine(t);
            }
            foreach (var r in ce.GetInt(true))
            {
                Console.WriteLine(r);
            }






            /**********************/
            ClassClonable cc = new ClassClonable();
            ClassClonable ccClone = cc.Clone() as ClassClonable;
            cc.ShowData();
            ccClone.ShowData();
            cc.ChangeData();
        
            
            cc.ShowData();
            ccClone.ShowData();
            
            ClassClonable deepCopied = cc.DeepCopy();
            Console.WriteLine("Deep Copy");
            
            deepCopied.ShowData();
            /**********************************/
            ClassComparable comp1 = new ClassComparable("pokolorowany");
            ClassComparable comp2 = new ClassComparable("powietrze");
            ClassComparable comp3 = new ClassComparable("co");
            ClassComparable comp4 = new ClassComparable("kazdy");
            ClassComparable comp5 = new ClassComparable("tyl");
            List<ClassComparable> compList = new List<ClassComparable>() { comp1, comp2, comp3, comp4, comp5 };
            compList.Sort();
            foreach( var t in compList)
            {
                Console.WriteLine(t.Name);
            }


            compList.Sort(new NamingComparer());
            foreach (var t in compList)
            {
                Console.WriteLine(t.Name);
            }


            comp1.CompareTo(comp2);
            

         //   if (comp1 > comp2) Console.WriteLine("OK");

        }
    }
    [Serializable]
    class AirPlanes : IAirCraft
    {
        Dictionary<int, string> myDict;
        public AirPlanes()
        {
            myDict = new Dictionary<int, string> { { 0, "none" }, { 1, "airbus" }, { 2, "boeing" }, { 3, "bombardier" } };
        }
        public string this[int number]
        {
            get
            {
                return myDict?[number>=myDict.Count? myDict.Count-1 : number] ?? "empty";
            }

            set
            {
                myDict[number] = value;
            }
        }

        string IAirCraft.this[int number]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int EnginesNr { get; set; }

        int IAirCraft.EnginesNr
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        int IMachine.machinename
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public event MyDelegate myEvent;

        event MyDelegate IAirCraft.myEvent
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void Landing()
        {
            throw new NotImplementedException();
        }

        void IAirCraft.Landing()
        {
            throw new NotImplementedException();
        }
    }
}
