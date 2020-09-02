using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShortUrl.Models
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class LinksContext : DbContext
    {
        public LinksContext(DbContextOptions options) : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<Link> Links { get; set; }
    }
}
