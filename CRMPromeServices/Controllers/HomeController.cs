using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPromeServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
             Table SQL -----> MVC vs. WebAPI
             */



            ViewBag.Title = "Home Page";
            
            return View();
        }
    }
}
