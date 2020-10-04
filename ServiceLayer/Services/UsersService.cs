using DataAccessLayer.Core.Repositories;
using DynamicExpresso;
using Entities.Models;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UsersService : IUserService 
    {
        private IUserRepository _dbUsers;
        private IUnitOfWork _unitOfWork;
        public UsersService(IUserRepository dbUsers, IUnitOfWork unitOfWork)
        {
            _dbUsers = dbUsers;
            _unitOfWork = unitOfWork;
        }
        public User GetUser(int usrId)
        {
            var dbUser = _dbUsers.Get(usrId);

            return dbUser;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var dbUsers = _dbUsers.GetAll();

            return dbUsers;
        }

        public User AddUser(User usr)
        {
            _dbUsers.Add(usr);

            var com =  _unitOfWork.Complete();

            var user = _unitOfWork.Users.Find(x => x.Email == usr.Email);

            return user.FirstOrDefault();
        }

        public User UpdateUser(User usr)
        {
           var editedUser =  _dbUsers.UpdateUser(usr);

            var com = _unitOfWork.Complete();

            return editedUser;

        }

        public int DeleteUser(int userId)
        {
            var dbUser = _dbUsers.Get(userId);

            if (dbUser == null) return 0;

            _dbUsers.Remove(dbUser);

            return _unitOfWork.Complete();
        }

        public bool CheckUserExist(string email)
        {
            var exists = _dbUsers.ChecUserExistsk(email);
            if(exists != null)
            {
                return true;
            }
            return false;
        }
    }
}
