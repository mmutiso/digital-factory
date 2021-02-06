using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public class IOUDbContext : DbContext
    {
        public IOUDbContext(DbContextOptions<IOUDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(options =>
            {
                options.HasKey(x => x.Name);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<IOU> IOUs { get; set; }
    }
}
