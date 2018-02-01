using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistASP.Models;

namespace CommunityAssistASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            CommunityAssist2017Entities2 DB = new CommunityAssist2017Entities2();
        
            //Add Grant types to View
            return View(DB.GrantTypes.ToList());
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