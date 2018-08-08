using System;
using System.Linq;
using System.Reflection;
using MarkI.Domain;
using MarkI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MarkI.WebApi.Tests
{
    public class PersonControllerTest
    {
        private Mock<IPerson> _mockRepository;
        private Person _invalidPerson;
        private Person _person;

        public PersonControllerTest()
        {
            _mockRepository = new Mock<IPerson>();
            _invalidPerson = new Person { Name = "Giovis", LastName = "Kaviedes", DocumentId = string.Empty, Email = "giovissexy69@ups.edu.ec" };
            _person = new Person { Name = "Giovis", LastName = "Kaviedes", DocumentId = "171984243213", Email = "giovissexy69@ups.edu.ec" };
            
        }

        [Fact]
        public void ShouldReturn200WhenSendValidPerson()
        {
            _mockRepository.Setup(repo => repo.Add(_person)).Returns(true);

            var currentResponse = new PersonController(_mockRepository.Object).Add(_person);

            Assert.IsType<OkResult>(currentResponse);
            
        }

        [Fact]
        public void ShouldReturn400WhenSendInvalidPerson()
        {
            
            _mockRepository.Setup(repo => repo.Add(_invalidPerson)).Verifiable();

            var currentResponse = new PersonController(_mockRepository.Object).Add(_invalidPerson);

            Assert.IsType<BadRequestResult>(currentResponse);
            
        }

         [Fact]
        public void ShouldReturn503WhenGetThrowException()
        {            
            const int statusCodeExpected = 503;
            
            _mockRepository.Setup(repo => repo.Add(_person)).Throws(new Exception());
            var currentResponse = new PersonController(_mockRepository.Object).Add(_person);

            var currentCode = Assert.IsType<StatusCodeResult>(currentResponse);
            Assert.Equal(statusCodeExpected, currentCode.StatusCode);
        }

         [Fact]
        public void ShouldBeAControllerClass()
        {
           var classParent = typeof(PersonController).BaseType.Name;
            const string ExpectedParentType = "Controller";
            Assert.Equal(ExpectedParentType, classParent);

        }

         [Fact]
        public void ShouldHaveRouteAttributeInClass()
        {
            var classAttributes = typeof(PersonController).GetCustomAttributes(typeof(RouteAttribute),false).FirstOrDefault();
 
            Assert.IsType<RouteAttribute>(classAttributes);
        }

        [Fact]
        public void ShouldHaveHttpPostAttributeInAddMethod()
        {
            MethodBase method = typeof(PersonController).GetMethod("Add");
            var mathodAttributes = method.GetCustomAttributes(typeof(HttpPostAttribute),false).FirstOrDefault();
 
            Assert.IsType<HttpPostAttribute>(mathodAttributes);
        }

        [Fact]
        public void ShouldBeFromBodyParam()
        {
            MethodBase method = typeof(PersonController).GetMethod("Add");

            var parameters = method.GetParameters();
            var attributesParameters= parameters[0].GetCustomAttributes(typeof(FromBodyAttribute),false);
            
            Assert.True(attributesParameters.Length > 0);
        }
    }
}