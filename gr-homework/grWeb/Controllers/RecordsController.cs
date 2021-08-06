using gr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace grWeb.Controllers
{
    public class RecordsController : ApiController
    {
        public static readonly List<Person> Persons = new List<Person>();

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

        public void Post()
        {
            // read content instead of creating a text/plain formatter
            var content = Task.Run(Request.Content.ReadAsStringAsync).Result;

            var person = Person.Parse(content);

            if (person == null) throw new Exception("Failed to parse");

            Persons.Add(person);
        }
    }
}