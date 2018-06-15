using System;
using System.Threading.Tasks;
using MarkI.IRepository;
using MarkI.Login;
using Microsoft.AspNetCore.Mvc;

namespace MarkI.WebApi.Controllers
{
    public class LoginController : Controller
    {
        private IUsers usersRepositoryTest;

        public LoginController(IUsers usersRepositoryTest)
        {
            this.usersRepositoryTest = usersRepositoryTest;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Credentials model)
        {
            try
            {
                var response = new Autorizer(usersRepositoryTest).Autorize(model.User,model.Password);

                if(response)
                    return new OkResult();
            }
            catch(Exception e)
            {
                return new BadRequestResult();        
            }
            
            return new BadRequestResult();
        }
    }
}