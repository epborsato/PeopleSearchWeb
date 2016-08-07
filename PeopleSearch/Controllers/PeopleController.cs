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
using PeopleSearch.Models;

namespace PeopleSearch.Controllers
{
    public class PeopleController : ApiController
    {
        private PeopleContext db = new PeopleContext();

        public PeopleController() {}

        public PeopleController(PeopleContext context)
        {
            this.db = context;
        }



        // GET: api/People
        public IQueryable<People> GetPeople()
        {
            return db.People;
        }


        // GET: api/People/5
        [ResponseType(typeof(People))]
        public People GetPeople(int id)
        {
            return db.People.FirstOrDefault(people => people.Id == id);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPeople(int id, People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != people.Id)
            {
                return BadRequest();
            }

            db.Entry(people).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
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

        // POST: api/People
        [ResponseType(typeof(People))]
        public async Task<IHttpActionResult> PostPeople(People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(people);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = people.Id }, people);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(People))]
        public async Task<IHttpActionResult> DeletePeople(int id)
        {
            People people = this.GetPeople(id);
            if (people == null)
            {
                return NotFound();
            }

            db.People.Remove(people);
            await db.SaveChangesAsync();

            return Ok(people);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeopleExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}