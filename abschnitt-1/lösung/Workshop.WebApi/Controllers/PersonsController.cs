using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Workshop.WebApi.Models;

namespace Workshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private static Dictionary<int, Person> store { get; } = new Dictionary<int, Person> {
            { 1, new Person{ Id = 1, Name = "Peter Peterson" } },
            { 2, new Person{ Id = 2, Name = "Klaus Klausens" } },
            { 3, new Person{ Id = 3, Name = "Singa Singable" } },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPersons() {
            return Ok(store.Values.ToList());
        }

        [HttpGet("{id}", Name = nameof(GetPersonById))]
        public ActionResult GetPersonById(int id) {
            return Ok(store[id]);
        }

        [HttpPost]
        public ActionResult PostPerson([FromBody] Person person) {
            if (store.ContainsKey(person.Id)) { 
                ModelState.AddModelError(nameof(person.Id), "Resource with the id already exists"); 
            }
            if (ModelState.IsValid) {
                store.Add(person.Id, person);
                return CreatedAtRoute(nameof(GetPersonById), new { person.Id }, person);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpPut("{id}")]
        public ActionResult PutPerson([FromRoute] int id, [FromBody] Person person) {
            if (!store.ContainsKey(id)) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState.ValidationState); }
            store[id] = person;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson([FromRoute] int id) {
            if (!store.ContainsKey(id)) { return NotFound(); }
            store.Remove(id);
            return NoContent();
        }

    }
}
