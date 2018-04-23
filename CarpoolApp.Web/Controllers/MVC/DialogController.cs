using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarpoolApp.Web.Controllers.MVC
{
    public class DialogController : Controller
    {
        // GET: Dialog
        public ActionResult Confirm()
        {
            return PartialView();
        }
    }
}