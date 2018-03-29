using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ASPModule.Infrastructure
{
    public class TimerModule : IHttpModule
    {

        private Stopwatch timer;
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleEvent;
            context.EndRequest += HandleEvent;
        }

        private void HandleEvent(object o, EventArgs e)
        {
            // HttpContext ctxFromParam = ((HttpApplication) o).Context;
            HttpContext ctx = HttpContext.Current;
            if (ctx.CurrentNotification == RequestNotification.BeginRequest)
            {
                timer = Stopwatch.StartNew();
            }
            else if (ctx.CurrentNotification == RequestNotification.EndRequest)
            {
                ctx.Response.Write(string.Format(
                    "<div class='alert alert-success'>Elapsed: {0:F5} seconds</div>",
                    ((float)timer.ElapsedTicks) / Stopwatch.Frequency));
                timer.Stop();
            }
        }
    }
}