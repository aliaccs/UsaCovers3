using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using US.Backend.Models;
using US.Common.Models;

namespace US.Backend.Controllers
{
    public class SalesCustomersController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: SalesCustomers
        public async Task<ActionResult> Index()
        {
            return View(await db.SalesCustomers.ToListAsync());
        }

        // GET: SalesCustomers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesCustomers salesCustomers = await db.SalesCustomers.FindAsync(id);
            if (salesCustomers == null)
            {
                return HttpNotFound();
            }
            return View(salesCustomers);
        }

        // GET: SalesCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RefNum1,Custom1,DateOR,DateSH,TotSales,TotGen,RF1,RF2,RF3,RF4")] SalesCustomers salesCustomers)
        {
            if (ModelState.IsValid)
            {
                db.SalesCustomers.Add(salesCustomers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(salesCustomers);
        }

        // GET: SalesCustomers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesCustomers salesCustomers = await db.SalesCustomers.FindAsync(id);
            if (salesCustomers == null)
            {
                return HttpNotFound();
            }
            return View(salesCustomers);
        }

        // POST: SalesCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RefNum1,Custom1,DateOR,DateSH,TotSales,TotGen,RF1,RF2,RF3,RF4")] SalesCustomers salesCustomers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesCustomers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(salesCustomers);
        }

        // GET: SalesCustomers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesCustomers salesCustomers = await db.SalesCustomers.FindAsync(id);
            if (salesCustomers == null)
            {
                return HttpNotFound();
            }
            return View(salesCustomers);
        }

        // POST: SalesCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SalesCustomers salesCustomers = await db.SalesCustomers.FindAsync(id);
            db.SalesCustomers.Remove(salesCustomers);
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
