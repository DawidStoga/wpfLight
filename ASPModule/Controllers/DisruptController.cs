using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace ASPModule.Controllers
{
    public class DisruptController : Controller
    {
        // GET: Disrupt
        public ActionResult Index()
        {
            return View();
        }


    public ActionResult  LogIn()
    {
        return RedirectToAction("Index", "Disrupt");
    }

        public ActionResult ShowData()
        {

            return View();
        }

        public JsonResult Break(int val = 0)
        {
            int result = 100 / val;
            return Json(result);
        }
    }



}