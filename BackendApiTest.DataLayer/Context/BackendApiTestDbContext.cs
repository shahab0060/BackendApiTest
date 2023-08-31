using BackendApiTest.Domain.Entities.Person;
using BackendApiTest.Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;

namespace BackendApiTest.DataLayer.Context
{
    public class BackendApiTestDbContext : DbContext
    {
        public BackendApiTestDbContext(DbContextOptions<BackendApiTestDbContext> options) : base(options)
        {

        }

        #region person

        public DbSet<Person> People { get; set; }

        #endregion

        #region transaction

        public DbSet<Transaction> Transactions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region cascade

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion

            #region Seed Data

            #region person

            modelBuilder.Entity<Person>()
                .HasData(new Person()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    LatestEditDate = DateTime.Now,
                    Name = "shahab",
                    Family = "Bakhtiari"
                });

            #endregion

            #region transaction

            modelBuilder.Entity<Transaction>()
                .HasData(new Transaction()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    LatestEditDate = DateTime.Now,
                    EditCounts = 1,
                    PersonId = 1,
                    Price = 1000
                });

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }


}