using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataContext
{
    public class DataBaseContext : DbContext , IDbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
                opsBuilder.UseSqlServer(settings.SQLConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DataBaseContext> opsBuilder { get; set; }
            public DbContextOptions dbOptions { get; set; }
            private AppConfiguration settings { get; set; }

        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
        { }

        public static OptionsBuild ops = new OptionsBuild();

        //public DataBaseContext(DbContextOptions options) : base(options)
        //{

        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
