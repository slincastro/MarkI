using System;
using System.Threading.Tasks;
using MarkI.Domain;
using MarkI.IRepository;
using MarkI.Login;
using Microsoft.AspNetCore.Mvc;

namespace MarkI.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AutorizationController : Controller
    {
        private IUsers usersRepositoryTest;

        public AutorizationController(IUsers usersRepositoryTest)
        {
            this.usersRepositoryTest = usersRepositoryTest;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]Credentials model)
        {
            try
            {
                var response = new Autorizer(usersRepositoryTest).Autorize(model);

                if (response)
                    return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

            return new BadRequestResult();
        }
    }
}