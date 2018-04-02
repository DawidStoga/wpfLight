using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ASPModule.Models;

namespace ASPModule.Controllers
{
    public class ConfigController : Controller
    {
        // GET: Config
        public ActionResult Index()
        {
            Dictionary<string,string> configData = new Dictionary<string, string>();
           
            foreach (string key in WebConfigurationManager.AppSettings)
            {
                configData.Add(key, WebConfigurationManager.AppSettings[key]);
            }
           
         

            return View(configData);
        }

        public ActionResult ShowConfigs()
        {
            ConfigModelView config = new ConfigModelView();
            return View(config);
        }
    }
}