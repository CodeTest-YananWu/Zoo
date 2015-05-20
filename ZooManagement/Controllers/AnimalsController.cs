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

namespace ZooManagement.Controllers
{
    public class AnimalsController : ApiController
    {
        private DataStore db = new DataStore();

        // GET api/Default1
        public List<Animal> GetAnimals()
        {
            return db.Animals.ToList();
        }

        // GET api/Default1/5
        [ResponseType(typeof(Animal))]
        public IHttpActionResult GetAnimal(int id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT api/Default1/5
        public IHttpActionResult PutAnimal(int id, Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.Id)
            {
                return BadRequest();
            }

            db.Entry(animal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

        // POST api/Default1
        [ResponseType(typeof(Animal))]
        public IHttpActionResult PostAnimal(Animal animal)
        {
            animal.AnimalID = Guid.NewGuid().ToString().ToUpper().Substring(0, 6);
            animal.Id = db.Animals.Count() + 1;
            ModelState.Remove("animal.AnimalID");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Animals.Add(animal);
            db.Entry(animal.Zookeeper).State = EntityState.Unchanged;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = animal.Id }, animal);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(Animal))]
        public IHttpActionResult DeleteAnimal(int id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            db.Animals.Remove(animal);
            db.SaveChanges();

            return Ok(animal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalExists(int id)
        {
            return db.Animals.Count(e => e.Id == id) > 0;
        }
    }
}