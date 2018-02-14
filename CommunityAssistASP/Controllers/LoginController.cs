using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistASP.Models;

namespace CommunityAssistASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "UserName, Password, PersonKey")] Login lc)
        {
            CommunityAssist2017Entities2 db = new CommunityAssist2017Entities2();

            int loginresult = db.usp_Login(lc.UserName, lc.Password);
            if (loginresult != -1) 
{
                var uid = (from p in db.People
                           where p.PersonEmail.Equals(lc.UserName)
                           select p.PersonKey).FirstOrDefault();

                int pkey = (int)uid;
                Session["PersonKey"] = pkey; // Create a session variable

                Message msg = new Message();
                msg.MessageText = "Thank you, " + lc.UserName + " for logging in.";
                return RedirectToAction("Result", msg);

            }

            Message message = new Message();
            message.MessageText = "Invalid Login";
            return View("Result", message);

        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}