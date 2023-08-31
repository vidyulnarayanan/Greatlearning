using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FinaLProject2.Controllers
{
    public class UserController : Controller
    {
       
        public ActionResult UserHomePage()
        {
            return View();
        }
    }
}
