using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace Client.BaseLibrary
{
    public delegate string Response(int order);
    partial class Multithreaded
    {
      public static  void DelegateTest()
        {
            Response response = new Response((z) => { return z.ToString(); });
            //   response.BeginInvoke(5, new AsyncCallback( iar =>  iar. ),null);
           var IAr =  response.BeginInvoke(5, myCalback, "Thank for calling");
           

          

        }

        private static void myCalback(IAsyncResult ar)
        {
            var asyncState = ar as AsyncResult;

            Response res = (Response)asyncState.AsyncDelegate;
            var result  =   res.EndInvoke(ar);
            var message = ar.AsyncState;
            Console.WriteLine($"This is callback result: {result} and message: {message}");
          
        }
    }
}
