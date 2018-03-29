
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;
using System.Net.Http;


// 

namespace ASPModule
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            //  RegisterEvents();
            RegisterNotification();
        }
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void LifeCycleNotifyLogger(object o, EventArgs e)
        {
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }

            if (Context == null)
            {
                return;
            }
            string name = Context.CurrentNotification.ToString();
            if (Context.IsPostNotification)
            {
                name = "Post" + name;
            }
            eventList.Add(name);
        }
        private void LifeCycleEventLogger(string e)
        {
            using (FileStream fs = new FileStream("D:\\LifeCycle.txt", FileMode.Append))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(e);
                sw.Close();
            }
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            eventList.Add(e);

        }

        protected void RegisterNotification()
        {
            this.BeginRequest += LifeCycleNotifyLogger;

            this.AuthorizeRequest += LifeCycleNotifyLogger;
            this.PostAuthorizeRequest += LifeCycleNotifyLogger;

            this.AuthenticateRequest += LifeCycleNotifyLogger;
            this.PostAuthenticateRequest += LifeCycleNotifyLogger;

            this.MapRequestHandler += LifeCycleNotifyLogger;
            this.PostMapRequestHandler += LifeCycleNotifyLogger;

            this.AcquireRequestState += LifeCycleNotifyLogger;
            this.PostAcquireRequestState += LifeCycleNotifyLogger;

            this.PreRequestHandlerExecute += LifeCycleNotifyLogger;
            this.PostRequestHandlerExecute += LifeCycleNotifyLogger;

            this.ReleaseRequestState += LifeCycleNotifyLogger;
            this.PostReleaseRequestState += LifeCycleNotifyLogger;

            this.UpdateRequestCache += LifeCycleNotifyLogger;
            this.PostUpdateRequestCache += LifeCycleNotifyLogger;

            this.LogRequest += LifeCycleNotifyLogger;
            this.PostLogRequest += LifeCycleNotifyLogger;

            this.EndRequest += LifeCycleNotifyLogger;

            this.PreSendRequestContent += LifeCycleNotifyLogger;

            this.PreSendRequestHeaders += LifeCycleNotifyLogger;

            this.Error += LifeCycleNotifyLogger;

            this.RequestCompleted += LifeCycleNotifyLogger;
        }
        protected void RegisterEvents()
        {
            this.BeginRequest += (o, e) => { LifeCycleEventLogger("BeginRequest"); };

            this.AuthorizeRequest += (o, e) => { LifeCycleEventLogger("AuthorizeRequest"); };
            this.PostAuthorizeRequest += (o, e) => { LifeCycleEventLogger("PostAuthorizeRequest"); };

            this.AuthenticateRequest += (o, e) => { LifeCycleEventLogger("AuthenticateRequest"); };
            this.PostAuthenticateRequest += (o, e) => { LifeCycleEventLogger("PostAuthenticateRequest"); };

            this.MapRequestHandler += (o, e) => { LifeCycleEventLogger("MapRequestHandler"); };
            this.PostMapRequestHandler += (o, e) => { LifeCycleEventLogger("PostMapRequestHandler"); };

            this.AcquireRequestState += (o, e) => { LifeCycleEventLogger("AcquireRequestState"); };
            this.PostAcquireRequestState += (o, e) => { LifeCycleEventLogger("PostAcquireRequestState"); };

            this.PreRequestHandlerExecute += (o, e) => { LifeCycleEventLogger("PreRequestHandlerExecute"); };
            this.PostRequestHandlerExecute += (o, e) => { LifeCycleEventLogger("PostRequestHandlerExecute"); };

            this.ReleaseRequestState += (o, e) => { LifeCycleEventLogger("ReleaseRequestState"); };
            this.PostReleaseRequestState += (o, e) => { LifeCycleEventLogger("PostReleaseRequestState"); };

            this.UpdateRequestCache += (o, e) => { LifeCycleEventLogger("UpdateRequestCache"); };
            this.PostUpdateRequestCache += (o, e) => { LifeCycleEventLogger("PostUpdateRequestCache"); };

            this.LogRequest += (o, e) => { LifeCycleEventLogger("LogRequest"); };
            this.PostLogRequest += (o, e) => { LifeCycleEventLogger("PostLogRequest"); };

            this.EndRequest += (o, e) => { LifeCycleEventLogger("EndRequest"); };

            this.PreSendRequestContent += (o, e) => { LifeCycleEventLogger("PreSendRequestContent"); };

            this.PreSendRequestHeaders += (o, e) => { LifeCycleEventLogger("PreSendRequestHeaders"); };

            this.Error += (o, e) => { LifeCycleEventLogger("Error"); };

            this.RequestCompleted += (o, e) => { LifeCycleEventLogger("RequestCompleted"); };

        }
        protected void Applications_End()  // ASP framework uses reflection to look for Start and Stop methods
        {
            using (var fs = new FileStream("D://mvcClosed.txt", FileMode.Append))
            {
                var offset = 0;
                foreach (var module in this.Modules)
                {
                    var saveItem = module.ToString();

                    fs.Write(Encoding.ASCII.GetBytes(saveItem + "\n"), 0, saveItem.Length);
                    offset += saveItem.Length;
                }

            }

        }
    }
}
