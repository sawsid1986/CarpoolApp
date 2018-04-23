using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarpoolApp.Web.Controllers.MVC
{
    public class MyPostsController : Controller
    {
        // GET: MyPosts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEditPost()
        {
            return PartialView();
        }

        public ActionResult PostListItem()
        {
            return PartialView();
        }
    }
}