using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ASPModule.Infrastructure.Configuration;
using ASPModule.Models;

namespace ASPModule.Controllers
{
    public class ConfigController : Controller
    {
        private Dictionary<string, string> configData;
        // GET: Config
        public ActionResult Index()
        {
            configData = new Dictionary<string, string>();
           
            foreach (string key in WebConfigurationManager.AppSettings)
            {
                configData.Add(key, WebConfigurationManager.AppSettings[key]);
            }
           
         

            return View(configData);
        }

        public ActionResult Section()
        {
            configData = new Dictionary<string, string>();

            var def = WebConfigurationManager.GetSection("NewUserDefaults");
            var con = NewUserDefaultsSection.GetConfiguration().City;
            var nuDefaults =
                WebConfigurationManager.GetWebApplicationSection("newUserDefaults");
                //as NewUserDefaultsSection;
          var   nuDefaultsU = nuDefaults as NewUserDefaultsSection;
            configData.Add("City", nuDefaultsU.City);
            configData.Add("Country", nuDefaultsU.Country);
            configData.Add("Language", nuDefaultsU.Language);
            configData.Add("Region", nuDefaultsU.Region.ToString());
            return View("Index",configData);
        }
    }
}