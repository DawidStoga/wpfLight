using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleApp.Models;

namespace MVCModule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(HttpContext.Application["events"]);
        }
        [HttpPost]
        public ActionResult Index(Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null)
            {
                Votes.ChangeVote(color, (Color)oldColor);
            }
            else
            {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
            return View(HttpContext.Application["events"]);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}