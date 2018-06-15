using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MarkI.IRepository;
using MarkI.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MarkI.Login.Tests
{
    //reference : https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-2.1
    public class LoginControllerTest
    {
        [Fact]
        public async Task ShouldReturn200whenSendValidCredentials()
        {
            var controller = new LoginController(new UsersRepositoryTest());

            var model = new Credentials{ User = "Paul", Password = "EsponjaSexi69" };
            var result = await controller.Login(model);

            var viewResult = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void ShouldHaveHttpPostAttribute()
        {
            MethodBase method = typeof(LoginController).GetMethod("Login");
            var attr = method.GetCustomAttributes(typeof(HttpPostAttribute)).FirstOrDefault();
 
            Assert.IsType<HttpPostAttribute>(attr);
        }
    }
}