using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using US.Common.Models;
using US.Domain.Models;

namespace SalesApi.Controllers
{
    public class PendingOrdersController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PendingOrders
        public IQueryable<PendingOrders> GetPendingOrders()
        {
            // return db.PendingOrders.OrderBy(r => r.RefNum);
            return db.PendingOrders;
        }

        // GET: api/PendingOrders/5
        [ResponseType(typeof(PendingOrders))]
        public async Task<IHttpActionResult> GetPendingOrders(int id)
        {
            PendingOrders pendingOrders = await db.PendingOrders.FindAsync(id);
            if (pendingOrders == null)
            {
                return NotFound();
            }

            return Ok(pendingOrders);
        }

        // PUT: api/PendingOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPendingOrders(int id, PendingOrders pendingOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pendingOrders.Key1)
            {
                return BadRequest();
            }

            db.Entry(pendingOrders).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendingOrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PendingOrders
        [ResponseType(typeof(PendingOrders))]
        public async Task<IHttpActionResult> PostPendingOrders(PendingOrders pendingOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PendingOrders.Add(pendingOrders);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pendingOrders.Key1 }, pendingOrders);
        }

        // DELETE: api/PendingOrders/5
        [ResponseType(typeof(PendingOrders))]
        public async Task<IHttpActionResult> DeletePendingOrders(int id)
        {
            PendingOrders pendingOrders = await db.PendingOrders.FindAsync(id);
            if (pendingOrders == null)
            {
                return NotFound();
            }

            db.PendingOrders.Remove(pendingOrders);
            await db.SaveChangesAsync();

            return Ok(pendingOrders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PendingOrdersExists(int id)
        {
            return db.PendingOrders.Count(e => e.Key1 == id) > 0;
        }
    }
}