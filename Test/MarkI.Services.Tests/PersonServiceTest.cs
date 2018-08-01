using System.Collections.Generic;
using MarkI.Domain;
using MarkI.IRepository;
using Moq;
using Xunit;

namespace MarkI.Services.Tests
{
    public class PersonServiceTest
    {
        private Person _newGiovisPerson;
        private Mock<IPerson> _mockRepository;

        public PersonServiceTest()
        {
            _newGiovisPerson = new Person{Name = "Giovis",LastName = "Kaviedes", DocumentId = "171984243213" , Email = "giovissexy69@ups.edu.ec" };
            _mockRepository = new Mock<IPerson>();

        }

        [Fact]
        public void ShouldCallRepositoryAddWhenSendNewPerson()
        {
            _mockRepository.Setup(s => s.Add(_newGiovisPerson)).Verifiable();
            
            new PersonService(_mockRepository.Object).Add(_newGiovisPerson);

            _mockRepository.VerifyAll();
        }

        [Fact]
        public void ShouldGet3Persons()
        {
            List<Person> persons = LoadPersons();

            const int expectedPersons = 3;

            _mockRepository.Setup(s => s.Get()).Returns(persons);

            var currentPersons = new PersonService(_mockRepository.Object).Get();

            Assert.Equal(expectedPersons, currentPersons.Count);

        }

        [Fact]
        public void ShouldGet1PersonWhenISendValidId()
        {
            const string validDocumentNumber = "171984243213";
            var expectedPerson = _newGiovisPerson;
            _mockRepository.Setup(s => s.GetById(validDocumentNumber)).Returns(_newGiovisPerson);

            var currentPerson = new PersonService(_mockRepository.Object).GetById(validDocumentNumber);

            Assert.Equal(expectedPerson.Name , currentPerson.Name);
            Assert.Equal(expectedPerson.DocumentId , currentPerson.DocumentId);
            Assert.Equal(expectedPerson.LastName , currentPerson.LastName);
            Assert.Equal(expectedPerson.Email , currentPerson.Email);
            
        }

        private static List<Person> LoadPersons()
        {
            var newGiovis = new Person { Name = "Giovis", LastName = "Kaviedes", DocumentId = "171984243213", Email = "giovissexy69@ups.edu.ec" };
            var newSebits = new Person { Name = "Sebits", LastName = "Figuemora", DocumentId = "171984243214", Email = "gaby.morita@longui.com" };
            var newDamiDami = new Person { Name = "Dami", LastName = "Dami", DocumentId = "171984243215", Email = "Irlandes@leprechaun.ir" };

            var persons = new List<Person> { newGiovis, newSebits, newDamiDami };
            return persons;
        }
    }
}