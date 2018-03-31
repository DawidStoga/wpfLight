using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPModule.Infrastructure
{
    public class DayOfWeeksHandler:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var day = DateTime.Today.DayOfWeek.ToString();
           day = Enum.GetName(typeof(DayOfWeek), DateTime.Today.DayOfWeek);
            if (context.Request.CurrentExecutionFilePathExtension == ".json")
            {
                context.Response.ContentType = "application/json";
                context.Response.Write(string.Format("{{\"day\": \"{0}\"}}", day));
       
            }
            else
            {
                context.Response.ContentType = "tetx/html";
                context.Response.Write(string.Format("<div>It si {0} </div>", day));

            }

        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}