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
    public class PendingOrdersController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: PendingOrders
        public async Task<ActionResult> Index()
        {
            return View(await db.PendingOrders.ToListAsync());
        }

        // GET: PendingOrders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingOrders pendingOrders = await db.PendingOrders.FindAsync(id);
            if (pendingOrders == null)
            {
                return HttpNotFound();
            }
            return View(pendingOrders);
        }

        // GET: PendingOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PendingOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Key1,Custo,TotCusto,TType,DateOrder,DeliveryDate,RefNum,Supplier,Item,Qty,ReceivedQty,UnitPrice,Amount")] PendingOrders pendingOrders)
        {
            if (ModelState.IsValid)
            {
                db.PendingOrders.Add(pendingOrders);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pendingOrders);
        }

        // GET: PendingOrders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingOrders pendingOrders = await db.PendingOrders.FindAsync(id);
            if (pendingOrders == null)
            {
                return HttpNotFound();
            }
            return View(pendingOrders);
        }

        // POST: PendingOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Key1,Custo,TotCusto,TType,DateOrder,DeliveryDate,RefNum,Supplier,Item,Qty,ReceivedQty,UnitPrice,Amount")] PendingOrders pendingOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pendingOrders).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pendingOrders);
        }

        // GET: PendingOrders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingOrders pendingOrders = await db.PendingOrders.FindAsync(id);
            if (pendingOrders == null)
            {
                return HttpNotFound();
            }
            return View(pendingOrders);
        }

        // POST: PendingOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PendingOrders pendingOrders = await db.PendingOrders.FindAsync(id);
            db.PendingOrders.Remove(pendingOrders);
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
