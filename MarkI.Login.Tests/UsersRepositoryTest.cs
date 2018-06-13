using System.Collections.Generic;
using MarkI.IRepository;

namespace MarkI.Login.Tests
{
    internal class UsersRepositoryTest : IUsers
    {
        public Dictionary<string, string> GetUsers()
        {
            var users = new Dictionary<string,string>();
            users.Add("Paul","EsponjaSexi69");
            return users;
        }
    }
}