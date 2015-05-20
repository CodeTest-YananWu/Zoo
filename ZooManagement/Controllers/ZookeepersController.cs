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
using Models;
using System.Data.Entity.Validation;

namespace ZooManagement.Controllers
{
    public class ZookeepersController : ApiController
    {
        private DataStore db = new DataStore();

        // GET api/Zookeepers
        public IQueryable<Zookeeper> GetZookeepers()
        {
            return db.Zookeepers;
        }

        // GET api/Zookeepers/5
        [ResponseType(typeof(Zookeeper))]
        public IHttpActionResult GetZookeeper(int id)
        {
            Zookeeper zookeeper = db.Zookeepers.Find(id);
            if (zookeeper == null)
            {
                return NotFound();
            }

            return Ok(zookeeper);
        }

        // PUT api/Zookeepers/5
        public IHttpActionResult PutZookeeper(int id, Zookeeper zookeeper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zookeeper.Id)
            {
                return BadRequest();
            }

            db.Entry(zookeeper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZookeeperExists(id))
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

        // POST api/Zookeepers
        [ResponseType(typeof(Zookeeper))]
        public IHttpActionResult PostZookeeper(Zookeeper zookeeper)
        {
            zookeeper.StaffID = Guid.NewGuid().ToString().ToUpper().Substring(0, 6);
            zookeeper.Id = db.Zookeepers.Count() + 1;
            ModelState.Remove("zookeeper.StaffID");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zookeepers.Add(zookeeper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zookeeper.Id }, zookeeper);
        }

        // DELETE api/Zookeepers/5
        [ResponseType(typeof(Zookeeper))]
        public IHttpActionResult DeleteZookeeper(int id)
        {
            Zookeeper zookeeper = db.Zookeepers.Find(id);
            if (zookeeper == null)
            {
                return NotFound();
            }

            db.Zookeepers.Remove(zookeeper);
            db.SaveChanges();

            return Ok(zookeeper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZookeeperExists(int id)
        {
            return db.Zookeepers.Count(e => e.Id == id) > 0;
        }
    }
}