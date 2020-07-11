using System;
using Microsoft.EntityFrameworkCore;

namespace OpenAPIRonnies.Domain
{
    public class RonnyContext : DbContext
    {

        public RonnyContext(DbContextOptions<RonnyContext> options):base(options)
        {
        }

        public DbSet<Ronny> Ronnies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ronnyTable = modelBuilder.Entity<Ronny>();
            ronnyTable.HasKey(r => r.Id);
            ronnyTable.Property(r => r.Id).ValueGeneratedOnAdd();
            ronnyTable.Property(r => r.Name).HasMaxLength(100).IsRequired();
            ronnyTable.Property(r => r.Price).IsRequired();
            ronnyTable.Property(r => r.Created).IsRequired().ValueGeneratedOnAdd();

            ronnyTable.HasData(new Ronny
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.UtcNow,
                Name = "Cafe X",
                Price = 3.5
            }, new Ronny
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.UtcNow,
                Name = "Cafe Y",
                Price = 2.4
            }, new Ronny
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.UtcNow,
                Name = "Cafe Z",
                Price = 4.0
            });
        }
    }
}