using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CommonModule;

[assembly:PreApplicationStartMethod(typeof(CommonModule.ModuleRegistration),"RegisterModule")]
namespace CommonModule
{
    public class ModuleRegistration
    {
        public static void RegisterModule()
        {
            HttpApplication.RegisterModule(typeof(CommonModule.InfoModule));
        }
    }
}
