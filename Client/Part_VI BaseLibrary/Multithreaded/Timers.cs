using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Client.BaseLibrary
{
    partial class Multithreaded
    {

        static void TestTimers()
        {
            TimerCallback timerCB = new TimerCallback(
                (x) => { Console.Write("TimerCallback{}",x); });

           // Timer timer = new Timer(timerCB, "who", 3000, 15000);
           // Short version
            Timer timer = new Timer((x) => { Console.Write($" time {DateTime.Now.TimeOfDay}  result: {x.ToString()}"); }, "who", 3000, 15000);
         

        }


    }
}
