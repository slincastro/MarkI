using System;
using System.Net;
using MarkI.Domain;
using MarkI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MarkI.WebApi {
    [Route ("api/[controller]")]
    public class PersonController : Controller {
        private IPerson _repository;

        public PersonController (IPerson person) {
            this._repository = person;
        }

        [HttpPost]
        public IActionResult Add ([FromBody]Person person) {
            try {
                if (!person.IsValid ())
                    return new BadRequestResult ();

                _repository.Add (person);

                return new OkResult ();

            } catch (System.Exception) {

                return new StatusCodeResult ((int) HttpStatusCode.ServiceUnavailable);
            }

        }
    }
}