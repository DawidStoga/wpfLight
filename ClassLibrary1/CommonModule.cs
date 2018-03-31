using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using  System.Web.Http;
namespace CommonModule
{
    public class RequestTmerEventArgs : EventArgs
    {
        public float Duration { get; set; }
    }
    public class InfoModule:IHttpModule
    {
        private Stopwatch timer;
        public event EventHandler<RequestTmerEventArgs> RequestTimed;
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
                var duration = ((float)timer.ElapsedTicks) / Stopwatch.Frequency;
                var cached = ctx.Cache.Get("Day");
                if (cached != null && (bool) cached == false)
                {
                ctx.Response.Write(string.Format(
                    "<div class='alert alert-success'>Elapsed: {0:F5} seconds</div>",
                    duration));
                timer.Stop();
                }
                

                if (RequestTimed != null)
                {
                    RequestTimed(this, new RequestTmerEventArgs() { Duration = duration });
                }
            }
            ctx.Response.Write(string.Format(
                "<div class ='alert alert-success'>URL {0} Status: {1}</div>",
                ctx.Request.RawUrl, ctx.Response.Status
            ));
        }
        public void Dispose()
        {
          
        }
    }
}
