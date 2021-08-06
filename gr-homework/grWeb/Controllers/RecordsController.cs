using gr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace grWeb.Controllers
{
    public class RecordsController : ApiController
    {
        private static readonly List<Person> Persons = new List<Person>();

        [Route("records/color")]
        public IEnumerable<Person> GetSortedByColor()
        {
            return Persons.OrderBy(p => p.FavoriteColor);
        }

        [Route("records/birthdate")]
        public IEnumerable<Person> GetSortedByDateOfBirth()
        {
            return Persons.OrderBy(p => p.DateOfBirth);
        }

        [Route("records/name")]
        public IEnumerable<Person> GetSortedByLastName()
        {
            return Persons.OrderBy(p => p.LastName);
        }

        public async void Post()
        {
            var content = await Request.Content.ReadAsStringAsync();

            var person = Person.Parse(content);

            if (person == null) throw new Exception("Failed to parse");

            Persons.Add(person);
        }
    }
}