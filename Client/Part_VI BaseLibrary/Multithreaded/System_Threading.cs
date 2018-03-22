using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Client.ADVANCED.advLangFeatures;

namespace Client.BaseLibrary
{
    partial class Multithreaded
    {

        public static int global { get; set; } = 0;
        private static int intVal = 0;
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static object threadLock = new object();


        static void AddOne()
        {
        Thread.Sleep(620); // intVal++;
        Interlocked.Increment(ref intVal);
        }
        static void ReadOne()
        {
            Console.Write(" ," + intVal); 
        }

        static void Print()
        {
           /* Shorthand of Monitor
            Monitor.Enter(threadLock)
            try 
            {
            .....
            }
            finally 
            {
            Moniotor.Exit(threadLock)
            }
            */
            lock(threadLock) 
            {
            for (int inx = 0; inx<30; inx++)
                {
                    Thread.Sleep(2);
                    global = inx;
                    Console.Write(global + " ");
                }
            }
          
        }
        static void Avg()
        {
            global++;
            Console.BackgroundColor = ConsoleColor.Black;
            int sum = 0;
            Console.WriteLine("\nStarting...{0}    ID:{1}", Thread.CurrentThread.ThreadState, Thread.CurrentThread.Name);
            for (int i = 0; i < 30; i++)
            {
                
                sum+= i;
                Console.Write(" {0}", i++);
            }
            Console.WriteLine("global: {0}", global);
        }
        static void AvgWithDelays()
        {
           
           // Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Starting...{0}  {1}", Thread.CurrentThread.ThreadState, Thread.CurrentThread.Name);
            for (int i = 0; i < 20; i++)
            {
                int y = (int)(i * 8 * 16 / 2 * 100000);
                int r = 2000 * 8 - 1000 * 16;
                Thread.Sleep(200+(y* r));
                Console.Write(" {0}", i);
            }
            Console.WriteLine();
        }

        static void ParamAvg(object param)
        {
            Console.WriteLine("Starting...{0}  {1}", Thread.CurrentThread.ThreadState, Thread.CurrentThread.Name);
            for (int i = 0; i < (int)param; i++)
            {
                int y = (int)(i * 8 * 16 / 2 * 100000);
                int r = 2000 * 8 - 1000 * 16;
                Thread.Sleep(200 + (y * r));
                Console.Write(" {0}", i);
            }
            waitHandle.Set();
            Console.WriteLine();
        }


        public static void   ThreadExamples()
        {
           
       /*   
            String.Format("------------------Start of ThreadExample: ", global).WriteWithColor(ConsoleColor.Blue);
            "============example_1 -  simple thread =========================".WriteWithColor(ConsoleColor.Red);
            SimpleThread();
            "=============End -  simple thread ==============================".WriteWithColor(ConsoleColor.DarkRed);
            Thread.Sleep(10000);

         

            "============example_2 -  thread with delay =====================".WriteWithColor(ConsoleColor.Red);
            ThreadWithDelay();
            "============End -  thread with delay============================".WriteWithColor(ConsoleColor.DarkRed);
 

            Thread.Sleep(10000);
            "============example_3 -  thread with delay  + Join==============".WriteWithColor(ConsoleColor.Red);
            ThreadWithJoin();
            "============End -  thread with delay  + join====================".WriteWithColor(ConsoleColor.DarkRed);
            Thread.Sleep(4000);

  */

            "============example_4 -  thread with  Prio =====================".WriteWithColor(ConsoleColor.Red);
            ThreadsWithPrio();
            "============End -  thread with prio   ==========================".WriteWithColor(ConsoleColor.DarkRed);

            waitHandle.WaitOne();

 
            Thread.Sleep(4000);



            "============example_5 -  threads with  Lock=====================".WriteWithColor(ConsoleColor.Red);
            ThreadsWithLock();
            "============End -  thread with lock  ==========================".WriteWithColor(ConsoleColor.DarkRed);




            "============example_6 -  threads with  InterLock=====================".WriteWithColor(ConsoleColor.Red);
            ThreadsWithInterlock();
            "============End -  thread with Interlock  ==========================".WriteWithColor(ConsoleColor.DarkRed);



            "============example_7 -  threads with  Pool=====================".WriteWithColor(ConsoleColor.Red);
            ThreadsWithPool();
            "============End -  thread with Pool  ==========================".WriteWithColor(ConsoleColor.DarkRed);

          
            String.Format("------------------End of ThreadExample: ", global).WriteWithColor(ConsoleColor.Blue);
        }

        private static void ThreadsWithPool()
        {
         for(int i= 0; i<20; i++)
            {
              //  WaitCallback CB = new WaitCallback(delegate { Multithreaded.AvgWithDelays(); });
               // ThreadPool.QueueUserWorkItem(CB, null);
//OR
              ThreadPool.QueueUserWorkItem(
                    (x) => {
                        Multithreaded.AvgWithDelays();
                        Console.WriteLine("CB"); });

            }
        }

        public static void SimpleThread()
        {
        Thread t2 = new Thread(Avg) { Name = "T2" };
       //Second thread
        t2.Start();
        //Main thread
        Avg();
   
        }
        public static void ThreadWithDelay()
        {
            Thread t3 = new Thread(AvgWithDelays) { Name = "T3" };
            Avg();
            t3.Start();
            Console.WriteLine("Thread completed? -NO!!! {0}", Thread.CurrentThread.ThreadState);
        }
        private static void ThreadWithJoin()
        {
            Thread t3 = new Thread(AvgWithDelays) { Name = "T3" };
            Avg();
            t3.Start();
            t3.Join();
            Console.WriteLine("Thread completed! {0}", Thread.CurrentThread.ThreadState);
        }
        private static void ThreadsWithPrio()
        {
            Thread t2 = new Thread(Avg) { Name = "T2" };
            Thread t3 = new Thread(AvgWithDelays) { Name = "T3" };
            Thread t4 = new Thread(new ParameterizedThreadStart(ParamAvg)) { Name = "T4" };

            

            t2.Priority = ThreadPriority.Lowest;
            t3.Priority = ThreadPriority.Lowest;
            t4.Priority = ThreadPriority.Highest;


            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            Stopwatch SWTimer = Stopwatch.StartNew();
            t2.Start();
            t3.Start();
            t4.Start(100);

            SWTimer.Stop();
            Console.WriteLine("Elapsed time: {0}",SWTimer.ElapsedMilliseconds);
          
        }

        private static void ThreadsWithLock()
        {   var tWork = new Thread(Print);
           
            tWork.Start();
            Print();
        }
        private static void ThreadsWithInterlock()
        {
            global = 0;
            Thread[] tWork = new Thread[100];
            for (int i = 0; i < 100; i++)
            {
                tWork[i] = new Thread(AddOne);
            }
            Thread[] tWork2 = new Thread[100];
            for (int i = 0; i < 100; i++)
            {
                tWork2[i] = new Thread(ReadOne);
            }

            foreach (var th in tWork) 
                th.Start();
            foreach (var th in tWork2)
                th.Start();
        }

        private static void Increment()
        {
            AddOne();
            ReadOne();
        }

        public static void Run(int testNo)
        {
            SimpleThread();


          /*  Thread t2 = new Thread(Avg) { Name = "T2" };
            Thread t3 = new Thread(AvgWithDelays) { Name = "T3" };
            Thread t4 = new Thread(new ParameterizedThreadStart(ParamAvg));
            Stopwatch SWTimer = Stopwatch.StartNew();*/
            /*   Avg();

               t2.Start();
               t3.Start();
               t4.Start(100);


            switch (testNo)
            {
                case 0:
                    { }
                 break;

                case 1:
                    Console.WriteLine("example_2 - without Join");
                    t3.Start();
                    Console.WriteLine("Thread completed? -NO!!! {0}", Thread.CurrentThread.ThreadState);
                    break;

                case 2:
                
            Console.WriteLine("Example_3 - with Join");

                    t3.Start();
                    t3.Join();
                    Thread.Sleep(200);
                    Console.WriteLine("Thread completed! {0}", Thread.CurrentThread.ThreadState);
                    break;

                case 3:
                    t2.Priority = ThreadPriority.Lowest;
                    t3.Priority = ThreadPriority.Lowest;
                    t4.Priority = ThreadPriority.Highest;


                    Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
                    t2.Start();
                    t3.Start();
                    t4.Start(100);

                    SWTimer.Stop();
                    Console.WriteLine(SWTimer.ElapsedMilliseconds);
                    break;
            }*/

            
        }

      
    }
}
