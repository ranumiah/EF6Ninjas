namespace NinjaDomain.DataModel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBirthdayToNinja : DbMigration
    {
        // Rollout Logic
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "DateOfBirth", c => c.DateTime(nullable: false));
        }

        // Rollback Logic
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "DateOfBirth");
        }
    }
}
