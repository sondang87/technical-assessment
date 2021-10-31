using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.Models;

namespace Services
{
    public class DatabaseContext: DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<UserRole> UserRoles { get; set; }
        internal DbSet<Role> Roles { get; set; }
        internal DbSet<Document> Documents { get; set; }
        internal DbSet<DocumentProperty> DocumentProperties { get; set; }
        internal DbSet<Keyword> Keywords { get; set; }
        internal DbSet<DocumentKeyword> DocumentKeywords { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        #region overriding of Created and Updated while save to db

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedOn").CurrentValue = DateTime.Now;
                E.Property("UpdatedOn").CurrentValue = DateTime.Now;
            });


            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedOn").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedOn").CurrentValue = DateTime.Now;
                E.Property("UpdatedOn").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedOn").CurrentValue = DateTime.Now;
            });

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>().HasQueryFilter(d => d.IsDel != true);
            modelBuilder.Entity<Document>().HasData (
                new Document { DocumentId = Guid.Parse("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"), DocumentName = "Document A", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("529bdc1a-8e86-4cf3-bfae-1f6be13775f2"), DocumentName = "Document B", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("882b9cfc-691d-4813-a2f0-78b3d3ec3cfe"), DocumentName = "Document C", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("ae630703-cbd1-471d-907f-52b757b7eb0e"), DocumentName = "Document D", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("ea091284-55c7-4c0b-bf0d-ccc4498d41a9"), DocumentName = "Document E", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("8ed5b22d-2610-4ca4-bba7-91183cc66511"), DocumentName = "Document F", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("876b6f77-dbea-452e-8638-d04000bd44b1"), DocumentName = "Document G", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("33b6ffc5-b4e1-4187-95cd-189d33857246"), DocumentName = "Document H", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("b6e27851-c365-4287-9c58-dea7ee86ee97"), DocumentName = "Document I", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now },
                new Document { DocumentId = Guid.Parse("2e7c54f2-f773-4e85-b4dd-b3f92f811a2b"), DocumentName = "Document K", DocumentType = "Promotion", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now }
            );

            modelBuilder.Entity<DocumentProperty>().HasData(
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"), Product = "Laptop", Supplier = "Supplier A", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("529bdc1a-8e86-4cf3-bfae-1f6be13775f2"), Product = "Monitor", Supplier = "Supplier A", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("882b9cfc-691d-4813-a2f0-78b3d3ec3cfe"), Product = "Laptop", Supplier = "Supplier B", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("ae630703-cbd1-471d-907f-52b757b7eb0e"), Product = "Monitor", Supplier = "Supplier B", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("ea091284-55c7-4c0b-bf0d-ccc4498d41a9"), Product = "Tablet", Supplier = "Supplier A", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("8ed5b22d-2610-4ca4-bba7-91183cc66511"), Product = "Laptop", Supplier = "Supplier C", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("876b6f77-dbea-452e-8638-d04000bd44b1"), Product = "Laptop", Supplier = "Supplier A", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("33b6ffc5-b4e1-4187-95cd-189d33857246"), Product = "Laptop", Supplier = "Supplier B", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("b6e27851-c365-4287-9c58-dea7ee86ee97"), Product = "Laptop", Supplier = "Supplier A", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now},
                new { Id = Guid.NewGuid(), DocumentId = Guid.Parse("2e7c54f2-f773-4e85-b4dd-b3f92f811a2b"), Product = "Laptop", Supplier = "Supplier C", CreatedBy = Guid.Parse("3b51e708-f9ff-4e4e-95bf-535085707374"), CreatedOn = DateTime.Now}
            );
        }
    }
}
