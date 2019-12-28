using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using US.Common.Models;
using US.Domain.Models;

namespace SalesApi.Controllers
{
    public class SalesCustomersController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/SalesCustomers
        public IQueryable<SalesCustomers> GetSalesCustomers()
        {
            return db.SalesCustomers.OrderBy(s => s.RefNum1);
        }

        // GET: api/SalesCustomers/5
        [ResponseType(typeof(SalesCustomers))]
        public IHttpActionResult GetSalesCustomers(int id)
        {
            SalesCustomers salesCustomers = db.SalesCustomers.Find(id);
            if (salesCustomers == null)
            {
                return NotFound();
            }

            return Ok(salesCustomers);
        }

        // PUT: api/SalesCustomers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesCustomers(int id, SalesCustomers salesCustomers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesCustomers.Id)
            {
                return BadRequest();
            }

            db.Entry(salesCustomers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesCustomersExists(id))
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

        // POST: api/SalesCustomers
        [ResponseType(typeof(SalesCustomers))]
        public IHttpActionResult PostSalesCustomers(SalesCustomers salesCustomers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesCustomers.Add(salesCustomers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salesCustomers.Id }, salesCustomers);
        }

        // DELETE: api/SalesCustomers/5
        [ResponseType(typeof(SalesCustomers))]
        public IHttpActionResult DeleteSalesCustomers(int id)
        {
            SalesCustomers salesCustomers = db.SalesCustomers.Find(id);
            if (salesCustomers == null)
            {
                return NotFound();
            }

            db.SalesCustomers.Remove(salesCustomers);
            db.SaveChanges();

            return Ok(salesCustomers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesCustomersExists(int id)
        {
            return db.SalesCustomers.Count(e => e.Id == id) > 0;
        }
    }
}