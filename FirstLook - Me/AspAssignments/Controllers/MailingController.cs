using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspAssignments.Models;

namespace AspAssignments.Controllers
{
    public class MailingController : Controller
    {
        // GET: Mailing
        public ActionResult Index()
        {
            // Create Jim Lahey Object
            Mailing m1 = new Mailing();
            m1.FirstName = "James";
            m1.LastName = "Lahey";
            m1.Email = "jlahey@sunnyvale.com";

            // Create Randy Object
            Mailing m2 = new Mailing();
            m2.FirstName = "Randy";
            m2.LastName = "Bobandy";
            m2.Email = "ilovecheeseburgers@sunnyvale.com";

            // Create George Green Object
            Mailing m3 = new Mailing();
            m3.FirstName = "George";
            m3.LastName = "Green";
            m3.Email = "dumbcop@dartmouthpd.ca";

            // Create Homer Simpson Object
            Mailing m4 = new Mailing();
            m4.FirstName = "Homer";
            m4.LastName = "Simpson";
            m4.Email = "hsimpson@springfieldnuclear.com";

            List<Mailing> mailings = new List<Mailing>();
            mailings.Add(m1);
            mailings.Add(m2);
            mailings.Add(m3);
            mailings.Add(m4);

            return View(mailings);
        }
    }
}