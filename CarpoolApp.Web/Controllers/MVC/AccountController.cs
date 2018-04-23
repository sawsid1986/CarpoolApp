using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarpoolApp.Web.Controllers.MVC
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return PartialView();
        }
    }
}