using NinjaDomain.Classes;
using System;
using System.Data.Entity;

namespace NinjaDomain.DataModel
{
    public static class Repository
    {
        private static void DbIntialise()
        {
            // Stop EF Default DB Initialisation process when working with DbContext 
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());

            #region EF by default checks the state of the DB & migration history
            /*
Opened connection at 13/10/2016 09:30:19 +01:00


SELECT Count(*)
FROM INFORMATION_SCHEMA.TABLES AS t
WHERE t.TABLE_SCHEMA + '.' + t.TABLE_NAME IN ('dbo.Clans','dbo.Ninjas','dbo.NinjaEquipments')
    OR t.TABLE_NAME = 'EdmMetadata'


-- Executing at 13/10/2016 09:30:19 +01:00

-- Completed in 27 ms with result: 3



Closed connection at 13/10/2016 09:30:19 +01:00

Opened connection at 13/10/2016 09:30:19 +01:00

SELECT
    [GroupBy1].[A1] AS [C1]
    FROM ( SELECT
        COUNT(1) AS [A1]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = @p__linq__0
    )  AS [GroupBy1]


-- p__linq__0: 'NinjaDomain.DataModel.Migrations.Configuration' (Type = String, Size = 4000)

-- Executing at 13/10/2016 09:30:19 +01:00

-- Completed in 3 ms with result: SqlDataReader



Closed connection at 13/10/2016 09:30:19 +01:00

Opened connection at 13/10/2016 09:30:19 +01:00

SELECT TOP (1)
    [Project1].[C1] AS [C1],
    [Project1].[MigrationId] AS [MigrationId],
    [Project1].[Model] AS [Model],
    [Project1].[ProductVersion] AS [ProductVersion]
    FROM ( SELECT
        [Extent1].[MigrationId] AS [MigrationId],
        [Extent1].[Model] AS [Model],
        [Extent1].[ProductVersion] AS [ProductVersion],
        1 AS [C1]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = @p__linq__0
    )  AS [Project1]
    ORDER BY [Project1].[MigrationId] DESC


-- p__linq__0: 'NinjaDomain.DataModel.Migrations.Configuration' (Type = String, Size = 4000)

-- Executing at 13/10/2016 09:30:19 +01:00

-- Completed in 1 ms with result: SqlDataReader



Closed connection at 13/10/2016 09:30:19 +01:00
             */
            #endregion


            #region Other DB Initialisation Options

            //Database.SetInitializer(new CreateDatabaseIfNotExists<NinjaContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NinjaContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
            //Database.SetInitializer(new myCustomDBInitializer());

            //Custom DB Initializer: You can also create your own custom initializer, if any of the above doesn't satisfy your requirements or you want to do some other process that initializes the database using the above initializer.
            //CreateDatabaseIfNotExists: This is default initializer.As the name suggests, it will create the database if none exists as per the configuration. However, if you change the model class and then run the application with this initializer, then it will throw an exception.
            //DropCreateDatabaseIfModelChanges: This initializer drops an existing database and creates a new database, if your model classes(entity classes) have been changed.So you don't have to worry about maintaining your database schema, when your model classes change.
            //DropCreateDatabaseAlways: As the name suggests, this initializer drops an existing database every time you run the application, irrespective of whether your model classes have changed or not.This will be useful, when you want fresh database, every time you run the application, like while you are developing the application.

            #endregion
        }

        public static void InsertClan()
        {
            DbIntialise();
            var clan = new Clan
            {
                ClanName = "Vermont Ninjas"
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;  // Allow us to view what is happening with EF behind the scene
                context.Clans.Add(clan);
                context.SaveChanges();  // Execute everything that the Context is tracking in a Transaction.
                                        // Therefore if there's a single failure then nothing will be changed.
            }

            #region SQL Statement EF EXEC
            /*
             Opened connection at 13/10/2016 09:36:37 +01:00

            Started transaction at 13/10/2016 09:36:37 +01:00

            INSERT [dbo].[Clans]([ClanName])
            VALUES (@0)
            SELECT [Id]
            FROM [dbo].[Clans]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Vermont Ninjas' (Type = String, Size = -1)

            -- Executing at 13/10/2016 09:36:37 +01:00

            -- Completed in 2 ms with result: SqlDataReader



            Committed transaction at 13/10/2016 09:36:37 +01:00

            Closed connection at 13/10/2016 09:36:37 +01:00

             */
            #endregion
        }
    }
}
