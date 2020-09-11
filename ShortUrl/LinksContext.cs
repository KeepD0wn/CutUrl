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
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Link>()
                .HasIndex(x => new { x.ShortUrl })
                .IsUnique(true);

            modelBuilder.Entity<Link>().Property(x => x.ShortUrl).IsRequired();            
        }

        public DbSet<Link> Links { get; set; }
    }
}
