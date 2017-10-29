using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.Del_Even_Lambda
{
    public  delegate int DelegClock(string godz);
    public delegate void GenDel<T>(T x) where T : struct;
    class Delegats
    {
        GenDel<int> myGenDel = new GenDel<int>(GenM);
       private static void GenM(int x)
        {
            Console.WriteLine("Gen<int> Method");
        }

        Action<string> astr = new Action<string>(TV);
        Func<string, int> fstr = new Func<string, int>(clock1);

        private static void TV(string obj)
        {
            //throw new NotImplementedException();
        }

        DelegClock myDeleg;// = new DelegClock(clock1);
        DelegClock myDelegAsync = new DelegClock(clock1);
        public Delegats()
        {
            myDeleg += (s) => { Console.WriteLine("Clock1" + int.Parse(s));  return 1; };
            
        }
        private static int clock1(string godz)
        {
            int cnt = 0;
            int.TryParse(godz, out cnt);
            Console.WriteLine("Clock1" +( int.TryParse(godz, out cnt)? cnt:777) );
            return 1;
        }

        public  void CallDelegat()

        {
            myDeleg.Invoke("10");
            myDeleg.Invoke("20");
           

        }
        public void CallDelegatAsync()

        {
          //  myDelegAsync.BeginInvoke("30", null, null);
         //   myDelegAsync.BeginInvoke("40", callBack, null);
            //myDelegAsync.BeginInvoke("50", ar => { myDelegAsync.EndInvoke(ar); Console.WriteLine("Innt AR"); }, null);
             myDelegAsync.BeginInvoke("100", callBack,"dawid");
        }
        
        void  callBack (IAsyncResult ia)
        {
            AsyncResult ar = (AsyncResult)ia;
          
            Console.WriteLine(ar.AsyncState.ToString()); 

            Console.WriteLine(myDelegAsync.EndInvoke(ia));
        }
       public void CallFuncAction()
        {
             int y =fstr("funktor");
           astr("Action");

        }
    }
    }
