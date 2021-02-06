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

            builder.Entity<IOU>(options =>
            {
                options.HasKey(x => x.Id);

                options.HasOne(x => x.Lender)
                .WithMany(x => x.LenderIOUs)
                .HasForeignKey(x => x.LenderId);

                options.HasOne(x => x.Borrower)
                .WithMany(x => x.BorrowerIOUs)
                .HasForeignKey(x => x.BorrowerId);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<IOU> IOUs { get; set; }
    }
}
