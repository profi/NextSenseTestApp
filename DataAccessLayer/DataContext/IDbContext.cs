using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataContext
{
    interface IDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }
       // DbSet<Rent> Rents { get; set; }
       // DbSet<Book> Books { get; set; }
    }
}
