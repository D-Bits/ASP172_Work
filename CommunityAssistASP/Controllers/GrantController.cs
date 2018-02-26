using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistASP.Models;
using CommunityAssistASP.Controllers;

namespace CommunityAssistASP.Controllers
{
    public class GrantController : Controller
    {
        CommunityAssist2017Entities2 db = new CommunityAssist2017Entities2();

        // GET: Request
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message m = new Message();
                m.MessageText = "You must be logged in to make a request";
                return RedirectToAction("Result", m);
            }

            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonEmail");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "GrantApplicationKey, PersonKey, GrantApplicationDate, GrantTypeKey, " +
            "GrantApplicationRequestAmount, GrantApplicationReason, GrantApplicationStatusKey" )]GrantRequest gr)

        {
            GrantApplication ga = new GrantApplication();
            ga.PersonKey = (int)Session["PersonKey"]; 
            ga.GrantAppicationDate = gr.GrantApplicationDate;
            ga.GrantTypeKey = gr.GrantTypeKey;
            ga.GrantApplicationRequestAmount = gr.GrantApplicationRequestAmount;
            ga.GrantApplicationReason = gr.GrantApplicationReason;
            ga.GrantApplicationStatusKey = gr.GrantApplicationStatusKey;

            db.GrantApplications.Add(ga);

            db.SaveChanges();
            Message m = new Message();
            m.MessageText = "Thank you for your application";
            return View("Result", m); 
        }

    }
}