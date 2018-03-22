using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Client.ADVANCED.advLangFeatures;
using System.Net;

namespace Client.BaseLibrary
{
    partial class Multithreaded
    {


        public static void TPFExamples()
        {
            // TestParallelFor();
            //TestNormalFor();
            // TestParallelForEach();
             //  Starting();
            // Waiting();
            //   Result();
            //Continuation();
           // TestParallelInvoke();
            // TestTaskCancelation();
            CallAsyc();
        }


        //The Role of the Parallel Class

        static void TestParallelInvoke()
        {
            WebClient wb = new WebClient();
           var webString =  wb.DownloadString(new Uri("http://tvn24.pl"));
            string[] words = webString.Split(new char[] { ' ', ',', '-' });
           

            Console.WriteLine("START");
            var act = new Action(() => {
                var res = from word in words where word.Contains("reklama") select word;

                foreach(var w in res)
                {
                    Console.WriteLine(w);
                }

                Console.WriteLine(DateTime.Now.Millisecond + ":    " + res); } );
           
           
                
               
            Parallel.Invoke(new[] { act });

            Console.WriteLine("END");
            wb.Dispose();
        }



            static void TestParallelFor()
        {
            List<int> started = new List<int>();
            List<int> finished = new List<int>();
            Random rd = new Random();
            CancellationToken ct = new CancellationToken();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = ct;
            var breakNo = rd.Next(1, 50);

            /*Simple example */
            Parallel.For(0, 10, (x) => { Console.WriteLine($" Hello {x}"); });

            /*Example with break*/
            Parallel.For(0, 100, po, (item, state) =>
            {
                started.Add(item);
                Console.WriteLine($"Iterator: {item}   started");
                Thread.Sleep(DateTime.Now.Millisecond * 10);
                if (item == 20)
                {
                    state.Break();
                    Console.WriteLine($"Stopped: {item}");
                }

                if (state.ShouldExitCurrentIteration)
                {
                    if (state.LowestBreakIteration < item)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("ShouldExit by {0}", item);
                    }

                }




                Console.WriteLine($"Iterator: {item}   finished");
                finished.Add(item);

            }
            );



            /* Process Result */
            finished.Sort();
            var NotFinished = started.Except(finished);
            var NotStarted = Enumerable.Range(1, 100).Except(started);
            int? c = NotFinished?.Count();

            /* Display Result */
            Console.WriteLine("\n\nBreak number: {0}", breakNo);
            Console.WriteLine("Started : {0}    minValue:{1}     ", started.Count, started.Min());
            String.Format("Finished: {0}    minValue:{1}     ", finished.Count, finished.Min()).WriteWithColor(ConsoleColor.Green);

            String.Format("\n\n Not finished:{0} (min:{1})", NotFinished?.Count() ?? 0, (NotFinished.Count() != 0 ? NotFinished.Min() : 0)).WriteWithColor(ConsoleColor.DarkRed);
            //    Console.WriteLine("\n\n Not finished:{0} (min:{1})", NotFinished?.Count() ?? 0, (NotFinished.Count() != 0 ? NotFinished.Min() : 0));
            foreach (var x in NotFinished)
            {
                Console.Write($"{x},");
            };
            Console.WriteLine("\n\n  Not  started yet: {0}  (min:{1})", NotStarted.Count(), NotStarted.Min());
            foreach (var x in NotStarted)
            {
                Console.Write($"{x},");
            };


        }
        static void TestParallelForEach()
        {
            //  Directory.CreateDirectory(@"E:\OperateOnFiles");
            string[] files = Directory.GetFiles(@"E:\DirInfo");
            var i = 1;
            byte[] Data = new byte[100000];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(files, file =>

             {
                 var filename = file;// Path.GetFileName(file);

                 using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite), fSave = new FileStream($@"E:\OperateOnFiless\file_s{DateTime.Now.Second}_m{DateTime.Now.Millisecond}_{i++}.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                 {
                     var sizedata = fs.Read(Data, 0, 100000);
                     fSave.Seek(0, SeekOrigin.End);
                     fSave.Write(Data, 0, sizedata);

                     fSave.Write(Encoding.ASCII.GetBytes(sw.Elapsed.Milliseconds.ToString()), 0, 2);
                     Thread.Sleep(500);
                 }

             });
            sw.Stop();
            Console.WriteLine(sw.Elapsed.Seconds + "." + sw.Elapsed.Milliseconds);



        }


        static void TestNormalFor()
        {
            var i = 1;
            //  Directory.CreateDirectory(@"E:\OperateOnFiles");
            string[] files = Directory.GetFiles(@"E:\DirInfo");
            byte[] Data = new byte[100000];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var file in files)
            {
                var filename = file;// Path.GetFileName(file);
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite), fSave = new FileStream($@"E:\OperateOnFiless\file_s{DateTime.Now.Second}_m{DateTime.Now.Millisecond}_{i++}.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var sizedata = fs.Read(Data, 0, 100000);
                    fSave.Seek(0, SeekOrigin.End);
                    fSave.Write(Data, 0, sizedata);

                    fSave.Write(Encoding.ASCII.GetBytes(sw.Elapsed.Milliseconds.ToString()), 0, 2);
                    Thread.Sleep(500);
                }

            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.Seconds + "." + sw.Elapsed.Milliseconds);
        }


        //The Task Class



        public static void Starting()
        {
            Console.WriteLine("=================== STARTING TASK + PROPERTIES===========================\n\n");
            Console.WriteLine("Main Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);

            //Factory.StartNew()

            var task_1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task_1 ( created by Factory.StartNew )  ID:{0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
               
            });

            Thread.Sleep(600);
            //Task propertieses:
            Console.WriteLine("=========Task properties :===========");
            
           Console.WriteLine($@" 
                AsyncState :    { task_1.AsyncState?.ToString()  }  
                CreationOption: {task_1.CreationOptions}
                Id:             {task_1.Id}
                IsCompleted:    {task_1.IsCompleted}
                IsFaulted:      {task_1.IsFaulted}
                Status:         {task_1.Status}"
                );
            //AsyncState not used these days
            //CreationOption - rarely read in real code  (for parent child tasks)
            //IsCompleted: RanToCompletion,Canceled, Faulted
            // Status   - task created by  Task.Run or Task.Factory.StartNew are in WaitingToRun
            //          - task created by ctrol are in Created
            //It moves to the WaitingToRun state when you assign it to a task scheduler via Start or RunSynchronously.

        
            Console.WriteLine("====== Tasks 2-4   - created by Task.Run() ==========");

            var task_2 = Task.Run(() => { Console.WriteLine("task_2  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(600); });
            var task_3 = Task.Run(() => { Console.WriteLine("task_3  ID:{0}", Thread.CurrentThread.ManagedThreadId); });
            var task_4 = Task.Run(() => { Console.WriteLine("task_4  ID:{0}", Thread.CurrentThread.ManagedThreadId); });

            //CurrentId only works for Delegate Tasks, not Promise Tasks.  returns the identifier of the currently-executing task, or null
            Console.WriteLine("Current executing Task ID: {0}",Task.CurrentId);

            Console.WriteLine("task4 Status: {0}", task_4.Status);
            task_2.ConfigureAwait(continueOnCapturedContext: true); //todo: wtf

           //Shouldn't be used with async.   Start state is "created"
           //Do not use it!
            Task task_5 = new Task(() => {
                Console.WriteLine("task_5 ( created by ctrol )  ID:{0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(300);
            }
            );

            Console.WriteLine("task5 Status: {0}",task_5.Status);

            //todo -description
            Task.WaitAny(task_2);

            Console.WriteLine("Check status of each Task");
            List<Task> tasks = new List<Task> {
                task_1,
                task_2,
                task_5,
                task_4,
                task_5 }
            ;
            Console.WriteLine("Taks Id  Completed   Status  ?");
            var taskNo = 0;
            foreach (var task in tasks)
            {
            Console.WriteLine("{0}   {1}    {2}", ++taskNo, task.IsCompleted, task.Status);

            }

            task_5.Start();
            taskNo = 0;
            Console.WriteLine("\nTaks Id  Completed   Status  ?");
            foreach (var task in tasks)
            {

                Console.WriteLine("{0}   {1}    {2}", ++taskNo, task.IsCompleted, task.Status);

            }

            /* Console.WriteLine("task 1: {0}  task 2: {1}  task_5 {2}", task_1.IsCompleted, task_2.IsCompleted, task_5.IsCompleted);
             Console.WriteLine("All task status ?");
             Console.WriteLine("task 1: {0}  task 2: {1}  task_5 {2}", task_1.Status, task_2.Status, task_5.Status);*/


            var task6 = Task.Run<int>(()=>{
                Console.WriteLine("task_6 ( created by Run<T> )  ID:{0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                int i = 0;
                var dirs = Directory.GetDirectories(Environment.SystemDirectory).AsEnumerable();

                Parallel.ForEach(Directory.GetDirectories(Environment.SystemDirectory).AsEnumerable(), dir => i += dir.Length);
                return i;
            });

            Console.WriteLine(" This is called after task_6");
            Console.WriteLine("result task_6: {0}",task6.Result);
            Console.WriteLine("task_6 finished  status : {0}", task6.Status);

        }
        public static void Waiting()
        {
            Stopwatch sw = new Stopwatch();
            CancellationTokenSource cs = new CancellationTokenSource(2000);
            CancellationToken ct = cs.Token;
            
            
            sw.Start();
            var task_w = Task.Run(() => { Console.WriteLine("task_1  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(1000); });
            task_w.Wait();
            sw.Stop();
            Console.WriteLine(" task.Wait() after {0}", sw.ElapsedMilliseconds / 1000f);

            sw.Restart();

            task_w = Task.Run(() => { Console.WriteLine("task_1  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(1000); });
            cs.CancelAfter(600);
            try
            {
                task_w.Wait(ct);
            }
            catch (AggregateException agex)
            {
                foreach (var ex in agex.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sw.Stop();
            Console.WriteLine(" task.Wait(ct) after {0}", sw.ElapsedMilliseconds / 1000f);



            sw.Restart();
             task_w = Task.Run(() => { Console.WriteLine("task_1  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(1000); });
            task_w.Wait(500);
            sw.Stop();
            Console.WriteLine(" task.Wait(500) after {0}", sw.ElapsedMilliseconds / 1000f);








            // WaitAll()
            sw.Restart();
            var task_1 = Task.Run(() => { Console.WriteLine("task_1  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(600); });
            var task_2 = Task.Run(() => { Console.WriteLine("task_2  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(800); });
            var task_3 = Task.Run(() => { Console.WriteLine("task_3  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(1200); });

            Task.WaitAll(new Task[] { task_1, task_2, task_3 });
            sw.Stop();
            Console.WriteLine(" Task.WaitAll after {0}", sw.ElapsedMilliseconds / 1000f);
           
            /* WhenAll()*/
            sw.Restart(); 
            task_1 = Task.Run(() => { Console.WriteLine("task_1  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(600); });
            task_2 = Task.Run(() => { Console.WriteLine("task_2  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(800); });
            task_3 = Task.Run(() => { Console.WriteLine("task_3  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(1200); });

            var whenAllTask = Task.WhenAll(new Task[] { task_1, task_2, task_3 });

            Task.WaitAny(whenAllTask);
            sw.Stop();
            Console.WriteLine("Task.WhenAll after {0} ", sw.ElapsedMilliseconds / 1000f);
            /* WhenAny()*/
            sw.Restart();
           
            task_1 = Task.Run(() => { Console.WriteLine("task_1  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(600); });
            task_2 = Task.Run(() => { Console.WriteLine("task_2  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(800); });
            task_3 = Task.Run(() => { Console.WriteLine("task_3  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(1200); });

            int endTaskNr = Task.WaitAny(new Task[] { task_1, task_2, task_3 });
            sw.Stop();
            Console.WriteLine(" Task.WaitAny(task) after {0}   retur int: {1} ", sw.ElapsedMilliseconds / 1000f,endTaskNr);

            sw.Restart();
            task_3 = Task.Run(() => { Console.WriteLine("task_3  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(8000); });
            Task.WaitAny(new Task[] { task_3 },new TimeSpan(0, 0, 0, 2));
            sw.Stop();
            Console.WriteLine(" Task.WaitAny(task, timeSpan) after {0}   retur int: {1} ", sw.ElapsedMilliseconds / 1000f, endTaskNr);

            sw.Restart();
            task_3 = Task.Run(() => { Console.WriteLine("task_3  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(6500); });
            var iar = (IAsyncResult)task_3;
            
            WaitHandle.WaitAny(new WaitHandle[] { iar.AsyncWaitHandle });
            sw.Stop();
            Console.WriteLine(" WaitHandle.WaitAny(new WaitHandle[] after {0}   retur int: {1} ", sw.ElapsedMilliseconds / 1000f, endTaskNr);
            //OR
            sw.Restart();
            task_3 = Task.Run(() => { Console.WriteLine("task_3  ID:{0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(3500); });
            iar = (IAsyncResult)task_3;
            iar.AsyncWaitHandle.WaitOne();
            sw.Stop();
            Console.WriteLine("  iar.AsyncWaitHandle.WaitOne() after {0}   retur int: {1} ", sw.ElapsedMilliseconds / 1000f, endTaskNr);



        }
        private static void Result()
        {
            var taskR = Task.Run<string>(() => { Thread.Sleep(3000);  return "TaskR"; });
            //task.Result synchronously blocks the calling thread
            //not good idea

            Console.WriteLine("taskR.Result {0}",taskR.Result);


            var taskGA = Task.Run<string>(() => { Thread.Sleep(3000); return "TaskGA"; });
            //task.Result synchronously blocks the calling thread
            //not good idea

            Console.WriteLine("taskR.Result {0}", taskGA.GetAwaiter().GetResult());
            

            // await  see Async.cs
        }
        private static void Continuation()
        {
            var taskCnt1 = Task.Run<string>(() => { Thread.Sleep(3000); Console.WriteLine(Task.CurrentId); return "TaskCnt"; });
            var taskCnt2 = Task.Run<string>(() => { Thread.Sleep(3000); Console.WriteLine(Task.CurrentId); return "TaskCnt"; });
            var taskCnt3 = Task.Run<string>(() => { Thread.Sleep(3000); Console.WriteLine(Task.CurrentId);  return "TaskCnt"; });

            taskCnt3.ContinueWith(t => Console.WriteLine(t.Id)).ContinueWith(x => Console.WriteLine(x.Id)); ;


            var taskCnt4 = Task.Run<string>(() => { Thread.Sleep(3000); Console.WriteLine(Task.CurrentId); return "TaskCnt"; });
            var taskCnt5 = Task.Run<string>(() => { Thread.Sleep(3000); Console.WriteLine(Task.CurrentId); return "TaskCnt"; });
            var taskCnt6 = Task.Run<string>(() => { Thread.Sleep(3000); Console.WriteLine(Task.CurrentId); return "TaskCnt"; });

           //taskCnt3.ContinueWith(t => Console.WriteLine(t.Id)).Unwrap().ContinueWith(x => Console.WriteLine(x.Id)); ;
         


        }
        public static void TestTaskCancelation()
        {
            Console.WriteLine("=================== TEST TASK CANCELATION======================\n\n");
            CancellationToken ct;
            CancellationTokenSource cts = new CancellationTokenSource();
            ct = cts.Token;
            var task1 = Task.Run(() =>
            {
             
                for (int i = 0; i < 10; i++)
                { if(ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                    }

                    Thread.Sleep(1000); Console.WriteLine("task_1  ID:{0}", Thread.CurrentThread.ManagedThreadId); }
            }, ct);
            var task2 = Task<int>.Run(() => { Thread.Sleep(1000); Console.WriteLine("task_2  ID:{0}", Thread.CurrentThread.ManagedThreadId);  return 8; });
            Thread.Sleep(3000);
            cts.Cancel();

           


            try
            {
               
                task1.Wait(ct);
             
                   

            }

            catch (AggregateException exs)
            {
                foreach (var exc in exs.InnerExceptions)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
            finally
            {
                cts.Dispose();
            }

            var res = task2.Result;
            Console.WriteLine("Task_2 result: {0}", res.ToString());


          var res2  =  task2.ContinueWith<string>((t) =>
            {

                t = new Task(() => { Console.WriteLine("Started"); t =  Task.Delay(2000);  t.Wait();   Console.WriteLine("I'm continuing..."); });
                t.Start();
                return t.Status.ToString();

            });
            var awaiter = res2.GetAwaiter();
            Console.WriteLine(   awaiter.ToString());

            Console.WriteLine("Task_2 result: {0}", res2.Result);


            Console.WriteLine("Finished");
        }


















        static public async void CallAsyc()
        {
            int res = await TakeIntAsync();
            int ret = await MethAsync();
             CallAsyncs();

            Console.WriteLine(ret);
            Console.WriteLine("Test");
        }
        static public async Task<int> MethAsync()
        {
            var t = await Task.FromResult<int>(DateTime.MaxValue.Millisecond);
            //  await Task.Delay(2200);
            Console.WriteLine("Delay {0}", t);
            Console.WriteLine("Dela");
            return t;

        }
        static public async Task<int> TakeIntAsync()
        {
            int x = await Task.Factory.StartNew(
                () =>
                {
                    int outi = 0;
                    for (int i = 0; i < 10000; i++)
                    {
                        var t = Enumerable.Range(0, i + 1);
                        outi += (int)t.Average();
                        if (0 == i % 500) Console.WriteLine(i);
                    }
                    return outi;
                }

                );

            Console.WriteLine("SecThread");
            return x;
        }

        static public void CallAsyncs()
        {
          
            Console.WriteLine(TakeIntAsync().Result);
            for (int z = 0; z < 10000; z++)
            {
                if (0 == z % 100)
                    Console.WriteLine("MainThread");
            }

        }

    }
}
