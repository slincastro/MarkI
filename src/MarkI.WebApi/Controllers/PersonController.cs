using System;
using System.Net;
using MarkI.Domain;
using MarkI.IRepository;
using MarkI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarkI.WebApi {
    [Route ("api/[controller]")]
    public class PersonController : Controller {
        private PersonService _service;

        public PersonController (IPerson person) {

            _service = new PersonService (person);
        }

        [HttpPost]
        public IActionResult Add ([FromBody] Person person) {
            try {
                if (!person.IsValid ())
                    return new BadRequestResult ();

                _service.Add (person);

                return new OkResult ();

            } catch (System.Exception) {

                return new StatusCodeResult ((int) HttpStatusCode.ServiceUnavailable);
            }

        }

        [HttpGet]
        public IActionResult Get () {
            try {

                return new OkObjectResult (_service.Get ());

            } catch (System.Exception) {

                return new StatusCodeResult ((int) HttpStatusCode.ServiceUnavailable);
            }

        }

        [HttpGet ("{id}")]
        public IActionResult GetById (string id) {
            try {
                var personResult = _service.GetById (id);
                return personResult != null ? new OkObjectResult (personResult) : (IActionResult) new NotFoundObjectResult ($"Value {id} not found");
            } catch (System.Exception) {

                return new StatusCodeResult ((int) HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}