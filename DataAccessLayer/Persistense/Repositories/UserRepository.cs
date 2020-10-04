using DataAccessLayer.Core.Repositories;
using DataAccessLayer.DataContext;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Persistense.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context)
        {
        }

        public User GetUser(int id)
        {
            return NextSenseContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return NextSenseContext.Users;
        }

        public User ChecUserExistsk(string email)
        {
            return NextSenseContext.Users.SingleOrDefault(x => x.Email == email);
        }

        public User UpdateUser(User usr)
        {
            var update = NextSenseContext.Users.Update(usr);

            return update.Entity;
        }

        public DataBaseContext NextSenseContext
        {
            get { return Context as DataBaseContext; }
        }
    }
}
