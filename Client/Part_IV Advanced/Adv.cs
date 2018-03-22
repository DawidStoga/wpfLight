using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ADVANCED.CollectionsAndGeneric;
using Client.ADVANCED.Del_Even_Lambda;
using Client.ADVANCED.advLangFeatures;

namespace Client.ADVANCED
{
    public class TestGen : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class Adv
    {
       public static void CollRun()
        {
            Collections<TestGen> col = new Collections<TestGen>();
            col.TestCollection();
            col.TestGenericCollecion();
            col.GenMethod<List<int>>(new List<int>() { 1, 2, 3, 4 });

        }
        public static void DelRun()
        {
            Delegats del = new Delegats();
            del.CallDelegat();
            del.CallDelegatAsync();
            del.CallFuncAction();
            Events events = new Events();
            events.TestEventPatern();


            Lambda l = new Lambda();
            l.Test();



           Indexer ind = new Indexer();
            ind.TestIndex();
           TestOperators toper = new TestOperators();
           toper.Test();
           toper.ExtMet(ConsoleColor.Blue);


            Linq.LinqToObject.NonGeneric();
           Linq.LinqToObject.FromGeneric();
            Linq.LinqToObject.CompareItems();



            ObjLifeTie.ObjLifeTime.TestGC();
        }

        
    }
}
