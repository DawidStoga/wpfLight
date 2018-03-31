using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPModule.Infrastructure
{
    public class CounterHandlerFactory : IHttpHandlerFactory
    {
        private int counter = 0;

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            if (context.Request.UserAgent.Contains("Chrome"))
            {
                return  new SiteLengthHandler();
            }
            else
            {
                        return  new CounterHandler(++counter);
            }
   

        }

        public void ReleaseHandler(IHttpHandler handler)
        {
           
        }
    }
}