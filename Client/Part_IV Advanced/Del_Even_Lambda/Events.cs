using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.Del_Even_Lambda
{
    public delegate T DEl<T>(T ins);
  

    class Publisher
    {   public event EventHandler<CustomEventArg> OnRise;  //compiler processes the C# event keyword, 
        //it generates two hidden methods, one having an add_prefix and the other having a remove_ prefix.
        public int money { get; set; }
        public void Div(int div)
        {
            try
            {
                money /= div;
            }
            catch (Exception ex)
            {
                OnRiseEvent(new CustomEventArg() { Message = ex.Message.ToString() });
            }
        }
     
        protected virtual void OnRiseEvent(CustomEventArg cusArg)
        {
            OnRise(this, cusArg);
        }

    }
    class Subscriber
    {
        public Subscriber(Publisher pub)
        {
            pub.OnRise += Pub_OnRise;
            pub.OnRise += (o, s) => { Console.Write("DAW"); };

        }

        private void Pub_OnRise(object sender, CustomEventArg e)
        {
            Console.WriteLine(sender.ToString() + " " + e.Message);
        }
    }
    class CustomEventArg:EventArgs
    {
            public String Message { get; set; }
       
        
        }













    class Events
    {
        public void TestEventPatern()
        {
            Publisher pub = new Publisher() { money = 120 };
            Subscriber sub = new Subscriber(pub);
            pub.Div(100);
            pub.Div(0);
        }


        public delegate void StogaHandler(Events o, CustomEventArg arg);
        public event DEl<int> EV;
        public event StogaHandler SH;
        public event EventHandler<CustomEventArg> RaiseCustomEvent;


        public Events()
        {
            EV += Events_EV;
            SH += Events_SH;
            RaiseCustomEvent += Events_RaiseCustomEvent;
            RaiseCustomEvent += delegate(object sender, CustomEventArg arg){/*....*/ };
            RaiseCustomEvent += (x, y) => { /*....*/};
        }

        private void Events_RaiseCustomEvent(object sender, CustomEventArg e)
        {
           // throw new NotImplementedException();
        }

        private void Events_SH(Events o, CustomEventArg arg)
        {
            
        }

        private int Events_EV(int ins)
        {
            Console.WriteLine("Event");
            return 0;
        }
    }
}
