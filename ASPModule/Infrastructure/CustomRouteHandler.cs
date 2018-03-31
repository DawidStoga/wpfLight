using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ASPModule.Infrastructure
{
    public class CustomRouteHandler : IRouteHandler
    {
        public Type  HandlerType { get; set; }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
   
            return (IHttpHandler)Activator.CreateInstance(HandlerType);

        }
    }
}