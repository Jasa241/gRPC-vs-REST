using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using grpcserver;

#nullable disable

namespace Cats.Context
{
    public partial class CatsContext : DbContext
    {
        public CatsContext()
        {
        }

        public CatsContext(DbContextOptions<CatsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasKey(e => e.Id);
        }
    }
}
