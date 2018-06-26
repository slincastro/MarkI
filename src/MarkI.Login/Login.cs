using System;
using MarkI.Domain;
using MarkI.IRepository;

namespace MarkI.Login
{
    public class Autorizer
    {
        IUsers _repository;
        public Autorizer(IUsers repository)
        {
            _repository = repository;            
        }

        public bool Autorize(Credentials crendentials)
        {
            if(string.IsNullOrEmpty(crendentials.UserName) || string.IsNullOrEmpty(crendentials.Password))
            {
                throw new ArgumentException("Invalid Credentials");
            }

            var users = _repository.GetUsers();

            string currentPassword ;

            if (users.TryGetValue(crendentials.UserName,out currentPassword))
                return  crendentials.Password.Equals(currentPassword);

            return false;
        }
    }
}