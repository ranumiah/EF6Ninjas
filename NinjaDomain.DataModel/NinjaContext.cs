using NinjaDomain.Classes;
using System.Data.Entity;

namespace NinjaDomain.DataModel
{
    // DbContext corresponds to the database
    // DbSet corresponds to a table or view in the database
    public class NinjaContext : DbContext // DbContext manages everything.
    {
        // DbSet is Repository, it's responsible for maintaining the in-memory collection of entities.
        // Query is perform using DbSets i.e.
        // From ==>  Ninjas.Where(x => x.ServedInOniwaban == true)
        // To   ==>  Select * from ninjas where ServedInOniwaban == true

        // Connection String Name in the App.config
        public NinjaContext() : base("NinjaDbConnection")
        {

        }

        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipment { get; set; }
    }
}
