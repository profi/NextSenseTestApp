using DataAccessLayer.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        //IBookRepository Books { get; }
        int Complete();
    }
}
