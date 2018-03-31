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
            var day = DateTime.Today.DayOfWeek.ToString();  /*1 way*/
            day = Enum.GetName(typeof(DayOfWeek), DateTime.Today.DayOfWeek); /*2 way*/

            if (context.Items.Contains("DayModule_Time")  && (context.Items["DayModule_Time"] is DateTime))

            {
                day = ((DateTime) context.Items["DayModule_Time"]).DayOfWeek.ToString(); /*3 way*/
                context.Response.Write("Day of Weeks sourced from DayMoudle_Time");
            }
         


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