using System;
using System.Collections.Generic;
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
        public void ShouldReturn503WhenAddThrowException()
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

        [Fact]
        public void ShouldReturn200With3PersonsWhenCallGetMethod()
        {
            var persons = LoadPersons();

            _mockRepository.Setup(s => s.Get()).Returns(persons);

            var response = new PersonController(_mockRepository.Object).Get();

            var viewResult = Assert.IsType<OkObjectResult>(response);

            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(viewResult.Value);
            Assert.Equal(3, model.Count());

        }

        [Fact]
        public void ShouldReturn503WhenGetPersonsThrowException()
        {            
            const int statusCodeExpected = 503;
            
            _mockRepository.Setup(repo => repo.Get()).Throws(new Exception());
            var currentResponse = new PersonController(_mockRepository.Object).Get();

            var currentCode = Assert.IsType<StatusCodeResult>(currentResponse);
            Assert.Equal(statusCodeExpected, currentCode.StatusCode);
        }

        [Fact]
        public void ShouldHaveHttpGetAttributeInGetMethod()
        {
            MethodBase method = typeof(PersonController).GetMethod("Get");
            var mathodAttributes = method.GetCustomAttributes(typeof(HttpGetAttribute),false).FirstOrDefault();
 
            Assert.IsType<HttpGetAttribute>(mathodAttributes);
        }

        [Fact]
        public void ShouldReturn200WithGiovisPersonWhenCallGetByIdMethod()
        {
            var persons = LoadPersons();
            var personId = "1";
            _mockRepository.Setup(s => s.GetById(personId)).Returns(_person);

            var response = new PersonController(_mockRepository.Object).GetById(personId);

            var viewResult = Assert.IsType<OkObjectResult>(response);

            var model = Assert.IsAssignableFrom<Person>(viewResult.Value);
            
            Assert.Equal("Giovis",model.Name);

        }

         [Fact]
        public void ShouldReturn404WhenSetInvalidPersonId()
        {
            var personId = "InvalidNumber";
            
            _mockRepository.Setup(repo => repo.GetById(personId)).Returns((Person)null);

            var currentResponse = new PersonController(_mockRepository.Object).GetById(personId);
            
            var viewResult = Assert.IsType<NotFoundObjectResult>(currentResponse); 
            var model = Assert.IsAssignableFrom<String>(viewResult.Value);
            Assert.Equal($"Value {personId} not found",model); 
        }

        [Fact]
        public void ShouldReturn503WhenGetPersonsByIdThrowException()
        {            
            const int statusCodeExpected = 503;

            string personId = "1";

            _mockRepository.Setup(repo => repo.GetById(personId)).Throws(new Exception());
            var currentResponse = new PersonController(_mockRepository.Object).GetById(personId);

            var currentCode = Assert.IsType<StatusCodeResult>(currentResponse);
            Assert.Equal(statusCodeExpected, currentCode.StatusCode);
        }

        [Fact]
        public void ShouldHaveHttpGetAttributeInGetByIdMethod()
        {
            MethodBase method = typeof(PersonController).GetMethod("GetById");
            var mathodAttributes = method.GetCustomAttributes(typeof(HttpGetAttribute),false).FirstOrDefault();
 
            Assert.IsType<HttpGetAttribute>(mathodAttributes);
        }
         private static List<Person> LoadPersons () {
            var newGiovis = new Person { Name = "Giovis", LastName = "Kaviedes", DocumentId = "171984243213", Email = "giovissexy69@ups.edu.ec" };
            var newSebits = new Person { Name = "Sebits", LastName = "Figuemora", DocumentId = "171984243214", Email = "gaby.morita@longui.com" };
            var newDamiDami = new Person { Name = "Dami", LastName = "Dami", DocumentId = "171984243215", Email = "Irlandes@leprechaun.ir" };

            var persons = new List<Person> { newGiovis, newSebits, newDamiDami };
            return persons;
        }
    }
}