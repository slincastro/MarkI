using System;
using MarkI.IRepository;

namespace MarkI.Login
{
    public class Login
    {
        IUsers _repository;
        public Login(IUsers repository)
        {
            _repository = repository;            
        }

        public bool Autorize(string userName, string password)
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Inavlid Credentials");
            }

            var users = _repository.GetUsers();

            string currentPassword ;

            if (users.TryGetValue(userName,out currentPassword))
                return  password.Equals(currentPassword);

            return false;
        }
    }
}