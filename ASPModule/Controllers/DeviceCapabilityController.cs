using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPModule.Models;

namespace ASPModule.Controllers
{
    public class DeviceCapabilityController : Controller
    {

        private Programmer[] progs = {
            new Programmer("Alice", "Smith", "Lead Developer", "Paris", "France", "C#"),
            new Programmer("Joe", "Dunston", "Developer", "London", "UK", "Java"),
            new Programmer("Peter", "Jones", "Developer", "Chicago", "USA", "C#"),
            new Programmer("Murray", "Woods", "Jnr Developer", "Boston", "USA", "C#")
        };
        // GET: DeviceCapability
        public ActionResult Index()
        {
            return View(progs);
        }

        public ActionResult Browser()
        {
            return View();
        }
    }
}