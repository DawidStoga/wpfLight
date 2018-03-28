using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using  System.Web.Http;
namespace CommonModule
{
    public class InfoModule:IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += (src, args) =>
            {
                HttpContext ctx = HttpContext.Current;
                ctx.Response.Write(string.Format(
                    "<div class ='alert alert-success'>URL {0} Status: {1}</div>",
                    ctx.Request.RawUrl, ctx.Response.Status
                    ));
            };
        }

        public void Dispose()
        {
          
        }
    }
}
