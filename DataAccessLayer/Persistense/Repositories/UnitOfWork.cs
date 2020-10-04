using DataAccessLayer.Core.Repositories;
using DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Persistense.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
           // Authors = new AuthorRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        //public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
