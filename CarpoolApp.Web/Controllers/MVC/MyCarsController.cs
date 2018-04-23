using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarpoolApp.Web.Controllers.MVC
{
    public class MyCarsController : Controller
    {
        // GET: MyCars
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCar()
        {
            return PartialView();
        }
    }
}