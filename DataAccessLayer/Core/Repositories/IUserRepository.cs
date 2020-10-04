using DataAccessLayer.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        User ChecUserExistsk(string email);
        User UpdateUser(User usr);
    }
}
