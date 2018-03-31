using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASPModule.Infrastructure.disruptingLifeCycle
{
    public class RedirectModule : IHttpModule
    {
        public void Dispose()
        {
          
        }

        public void Init(HttpApplication context)
        {

            context.MapRequestHandler += (o, e) =>
            {
                if (context.Request.Url.AbsoluteUri.Contains("LogIn"))
                {
                   // context.Response.Redirect("/Disrupt/Index");  OR
                    RouteValueDictionary rvd = context.Request.RequestContext.RouteData.Values;
                    //rvd.Where(x => x.Key == "Action" && x.Value == "LogIn").FirstOrDefault();
                    if (rvd.Any(x => x.Key == "action" && (string)x.Value == "LogIn"))
                    {
                        string url = UrlHelper.GenerateUrl("", "Index", "Disrupt", rvd, RouteTable.Routes,
                            context.Context.Request.RequestContext, false);
                      //  context.Response.Redirect("/Disrupt/Index");
                        context.Response.Redirect(url);
                    }
                }
            };
        }
    }
}