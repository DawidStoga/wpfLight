using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPModule.Infrastructure
{
    public class CounterHandler : IHttpHandler
    {
        private int handlerCounter;

        public CounterHandler(int counter)
        {
            this.handlerCounter = counter;
        }
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The counter value is {0}",
                handlerCounter));
        }
    }
}