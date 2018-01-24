using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityAssistASP.Models;

namespace CommunityAssistASP.Controllers
{
    public class BusinessRulesController : Controller
    {
        private CommunityAssist2017Entities1 db = new CommunityAssist2017Entities1();

        // GET: BusinessRules
        public async Task<ActionResult> Index()
        {
            return View(await db.BusinessRules.ToListAsync());
        }

        // GET: BusinessRules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = await db.BusinessRules.FindAsync(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // GET: BusinessRules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessRules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BusinessRuleKey,BusinessRuleText")] BusinessRule businessRule)
        {
            if (ModelState.IsValid)
            {
                db.BusinessRules.Add(businessRule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(businessRule);
        }

        // GET: BusinessRules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = await db.BusinessRules.FindAsync(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // POST: BusinessRules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BusinessRuleKey,BusinessRuleText")] BusinessRule businessRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessRule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(businessRule);
        }

        // GET: BusinessRules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = await db.BusinessRules.FindAsync(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // POST: BusinessRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BusinessRule businessRule = await db.BusinessRules.FindAsync(id);
            db.BusinessRules.Remove(businessRule);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
