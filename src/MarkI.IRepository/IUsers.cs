using System.Collections.Generic;

namespace MarkI.IRepository
{
    public interface IUsers
    {
         Dictionary<string,string> GetUsers();
    }
}