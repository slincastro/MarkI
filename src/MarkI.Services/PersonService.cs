using System;
using System.Collections.Generic;
using MarkI.Domain;
using MarkI.IRepository;

namespace MarkI.Services
{
    public class PersonService
    {
        private IPerson _repository;

        public PersonService(IPerson repository)
        {
            this._repository = repository;
        }

        public void Add(Person person)
        {
            person.Id = person.DocumentId;
            _repository.Add(person);
            
        }

        public List<Person> Get()
        {
            return _repository.Get();
        }

        public Person GetById(string validDocumentNumber)
        {
            return _repository.GetById(validDocumentNumber);
        }
    }
}