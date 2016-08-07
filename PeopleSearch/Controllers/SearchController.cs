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
using System.Threading;

namespace PeopleSearch.Controllers
{
    public class SearchController : ApiController
    {
        private PeopleContext db = new PeopleContext();

        // GET: api/Search

        public IQueryable<People> GetPeople()
        {
            return db.People;
        }

        // GET: api/Search/searchString
        [HttpGet]
        [Route("api/Search/{searchString}")]
        [ResponseType(typeof(People))]
        public IQueryable<People> GetPeople(string searchString)
        {
            var people = from p in db.People
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.FirstName.Contains(searchString));
            }
            if (searchString.StartsWith("s"))
            {
                Thread.Sleep(2500);
            }
            return people;

        }
    }
}