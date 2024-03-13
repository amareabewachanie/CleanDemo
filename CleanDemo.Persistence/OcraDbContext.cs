using CleanDemo.Domain.Common;
using CleanDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Persistence
{
    public class OcraDbContext : DbContext
    {
        public OcraDbContext(DbContextOptions<OcraDbContext> option):base(option)
        {
            
        }
        public DbSet<Birth> Births { get; set; }
        public DbSet<Death> Deaths { get; set; }
        public DbSet<Marriage> Marriages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OcraDbContext).Assembly);
            modelBuilder.Entity<Marriage>()
            .HasOne(m => m.Husband)
            .WithMany()
            .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Marriage>()
                .HasOne(m => m.Wife)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entity in ChangeTracker.Entries<AuditableEntity>()) {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.Now;
                        entity.Entity.CreatedBy = 1;
                        break;
                    case EntityState.Modified:
                        entity.Entity.UpdatedDate = DateTime.Now;
                        entity.Entity.UpdatedBy = 1;
                        break;
                     
                }
            
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
