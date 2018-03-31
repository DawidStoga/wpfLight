using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ASPModule.Infrastructure.disruptingLifeCycle
{
    public class HandlerSelectionModule : IHttpModule
    {
        public void Dispose()
        {
       
        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += (o, e) =>
            {
                if (Compare(context.Context.Request.RequestContext.RouteData.Values, "action", "ShowData"))
                {
                    if (DateTime.Now.Second > 30)
                    {
					context.Context.RemapHandler(new InfoHandler());
                    }
            
                }


            };
        }

        private bool Compare(RouteValueDictionary rvd, string key, string value)
            {
                return string.Equals((string)rvd[key], value,
                    StringComparison.OrdinalIgnoreCase);
            }
        }
}