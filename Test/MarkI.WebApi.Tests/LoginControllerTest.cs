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
            var controller = new AutorizationController(new UsersRepositoryTest());

            var model = new Credentials{ UserName = "Paul", Password = "EsponjaSexi69" };
            var result = await controller.Login(model);

            var viewResult = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ShouldReturn400whenSendInvalidCredentials()
        {
            var controller = new AutorizationController(new UsersRepositoryTest());

            var model = new Credentials{ UserName = "Paul", Password = "wrongPassword" };
            var result = await controller.Login(model);

            var viewResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ShouldReturn400whenSendEmptyCredentials()
        {
            var controller = new AutorizationController(new UsersRepositoryTest());

            var model = new Credentials{ UserName = "Paul", Password = string.Empty };
            var result = await controller.Login(model);

            var viewResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void ShouldHaveHttpPostAttributeInLoginMethod()
        {
            MethodBase method = typeof(AutorizationController).GetMethod("Login");
            var mathodAttributes = method.GetCustomAttributes(typeof(HttpPostAttribute),false).FirstOrDefault();
 
            Assert.IsType<HttpPostAttribute>(mathodAttributes);
        }

        [Fact]
        public void ShouldHaveRouteAttributeInClass()
        {
            var classAttributes = typeof(AutorizationController).GetCustomAttributes(typeof(RouteAttribute),false).FirstOrDefault();
 
            Assert.IsType<RouteAttribute>(classAttributes);
        }
    }
}