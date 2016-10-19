using NinjaDomain.Classes;
using NinjaDomain.Classes.Interfaces;
using NinjaDomain.DataModel.Migrations;
using System;
using System.Data.Entity;
using System.Linq;

namespace NinjaDomain.DataModel
{
    // DbContext corresponds to the database
    // DbSet corresponds to a table or view in the database
    internal class NinjaContext : DbContext // DbContext manages everything.
    {
        // DbSet is Repository, it's responsible for maintaining the in-memory collection of entities.
        // Query is perform using DbSets i.e.
        // From ==>  Ninjas.Where(x => x.ServedInOniwaban == true)
        // To   ==>  Select * from ninjas where ServedInOniwaban == true

        // Connection String Name in the App.config
        public NinjaContext() : base("NinjaDbConnection")
        {
            AttachDbFilename.SetDataDirectory();
        }

        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipment { get; set; }

        // Allows the change of default model binding conventions
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NinjaContext, Configuration>());

            // This will prevent EF to look for IsDirty in Model, Queries, and Updates
            modelBuilder.Types().Configure(c => c.Ignore("IsDirty"));
            base.OnModelCreating(modelBuilder);
        }

        // Altering the default SaveChange behaviour
        public override int SaveChanges()
        {
            PopulateEntityWithModificationHistoryData();
            int result = base.SaveChanges();  // The real SaveChanges where EF will push the changes to DB
            ResetIsDirty();
            return result;
        }

        private void PopulateEntityWithModificationHistoryData()
        {
            foreach (var history in this.ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IModificationHistory &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified))
                    .Select(e => e.Entity as IModificationHistory)
            )
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }
        }

        // This is useful for connected applications like WPF or Console app or windows forms.
        private void ResetIsDirty()
        {
            foreach (var history in this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IModificationHistory)
                    .Select(e => e.Entity as IModificationHistory)
                    )
            {
                history.IsDirty = false;
            }
        }
    }
}
