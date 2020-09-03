using Microsoft.EntityFrameworkCore;
using ShortUrl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShortUrl
{
    
    public class LinksContext : DbContext
    {
        public LinksContext(DbContextOptions options) : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<Link> Links { get; set; }
    }
}
