using System;

namespace MarkI.Login
{
    public class Login
    {
        public bool Autorize(string userName, string password)
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Inavlid Credentials");
            }
            return userName.Equals("Paul") && password.Equals("EsponjaSexi69");
        }
    }
}