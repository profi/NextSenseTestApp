using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IUserService
    {
        public User GetUser(int usrId);
        public User AddUser(User usr);
        public User UpdateUser(User usr);
        public int DeleteUser(int userId);
        public IEnumerable<User> GetAllUsers();
        public bool CheckUserExist(string email);

    }
}
