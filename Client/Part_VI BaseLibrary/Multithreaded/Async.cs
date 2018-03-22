using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Build.Tasks;
using Nito.AsyncEx;

namespace Client.BaseLibrary
{
   partial class  Multithreaded
    {
        static Stopwatch sw = new Stopwatch();
        public static async Task DoSomethingAsync()
        {
            sw.Restart();
            Console.WriteLine("Start async method");
            await Task.Delay(2000);  // instead of Thread.Sleep
            sw.Stop();
            Console.WriteLine(" Reminder  method  executed after : {0}", sw.ElapsedMilliseconds/1000f);
        }

        public static  async Task<int> ReturnSomethingAsync()
        {
           Console.WriteLine("Start ReturnSthgAsync method");
          sw.Restart();
          await Task.Delay(2000);
          var result =    await Task<int>.Run(() => { Thread.Sleep(3000); return 10; });   // instead of task.Result
            sw.Stop();
            Console.WriteLine(" Reminder  and result is consumed  after : {0}", sw.ElapsedMilliseconds / 1000f);
          return result;

        }
        public async Task<int> ReturnSomethingAsync2()
        {
            await Task.Delay(2000);// instead of Task wait
            return 88;

        }


        public async Task AwaitFromEveryTaskSource()
        {
            await MyExampleMethod();
            await MyExampleMethodAsync(200);
        }

        private static async Task MyExampleMethodAsync(int time)
        {
            await Task.Delay(time);
        }

        private static  Task MyExampleMethod()
        {
            return Task.Run(() => { Thread.Sleep(1200); });
        }

        private static  async Task WaitngAsync()
        {
        
            sw.Restart();
            Task[] tasks = new Task[3] { MyExampleMethodAsync(200), MyExampleMethodAsync(800), MyExampleMethodAsync(500) };
            await Task.WhenAll(tasks);
            Console.WriteLine("All Tasks completed  in {0} sec",sw.ElapsedMilliseconds/1000f);

            sw.Restart();
            tasks = new Task[3] { MyExampleMethodAsync(200), MyExampleMethodAsync(800), MyExampleMethodAsync(500) };
            await Task.WhenAny(tasks);
            Console.WriteLine("Fist Tasks was completed  in {0} sec", sw.ElapsedMilliseconds / 1000f);

        }


        public static async void RunExamplesAsync()
        {

            await DoSomethingAsync();
            for(var i=0; i<100; i++)
            {
                Thread.Sleep(10);
                Console.Write(".");
            }
          int x =  await  ReturnSomethingAsync();
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
            Console.WriteLine("Return: {0}:", x);
           await  WaitngAsync();
         x  =    await MyIntegerEventAsync();
            Console.WriteLine("Return: {0}:", x);
            //Retun void
            FunWithContexAsync();
        }


        public static int Main_example()  // simulate the main function
        {
            return AsyncContext.Run(AsyncMain); //from extension
        }

        static async Task<int> AsyncMain() => await Task.FromResult(2);

        static Task<int> MyIntegerEventAsync()
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1200);
                tcs.SetResult(1234);
            });

            Console.WriteLine("After seting the result");
            return tcs.Task;
        }

        private static async void FunWithContexAsync()
        {
            Console.WriteLine( Thread.CurrentContext.ContextID);
            await FunWithContexTask();
            Console.WriteLine(Thread.CurrentContext.ContextID);

        }
        private static async Task<int>  FunWithContexTask()
        {
            Console.WriteLine(Thread.CurrentContext.ContextID);
            var t = await Task.Factory.StartNew(() =>
            {
                Console.WriteLine(Thread.CurrentContext.ContextID);
                Thread.Sleep(2000); return 210;
            }).ConfigureAwait(false) ;
            Console.WriteLine(Thread.CurrentContext.ContextID);
            return t;

        }

    }

}
