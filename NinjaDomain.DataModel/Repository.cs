using NinjaDomain.Classes;
using NinjaDomain.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
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

        public static void InsertMultipleNinjas()
        {
            DbIntialise();
            var raphael = new Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(2000, 2, 29),
                ClanId = 1
            };
            var leonardo = new Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(2000, 2, 29),
                ClanId = 1
            };
            var michelangelo = new Ninja
            {
                Name = "Michelangelo",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(2000, 2, 29),
                ClanId = 1
            };
            var donatello = new Ninja
            {
                Name = "Donatello",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(2000, 2, 29),
                ClanId = 1
            };
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(new List<Ninja> { raphael, leonardo, michelangelo, donatello });
                context.SaveChanges();
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 18/10/2016 13:48:09 +01:00

            Started transaction at 18/10/2016 13:48:09 +01:00

            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Raphael' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '01/01/1984 00:00:00' (Type = DateTime2)

            -- Executing at 18/10/2016 13:48:09 +01:00

            -- Completed in 1 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Leonardo' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '01/01/1985 00:00:00' (Type = DateTime2)

            -- Executing at 18/10/2016 13:48:09 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Michelangelo' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '01/01/1986 00:00:00' (Type = DateTime2)

            -- Executing at 18/10/2016 13:48:09 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Donatello' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '01/01/1987 00:00:00' (Type = DateTime2)

            -- Executing at 18/10/2016 13:48:09 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            Committed transaction at 18/10/2016 13:48:09 +01:00

            Closed connection at 18/10/2016 13:48:09 +01:00
             */
            #endregion
        }

        public static void SimpleNinjaQueries()
        {
            DbIntialise();
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                // Either LINQ methods or LINQ Query Syntax can be used for Expressing Queries.
                var ninjas = context.Ninjas
                    .Where(n => n.DateOfBirth >= new DateTime(2000, 2, 29))
                    .OrderBy(n => n.Name)
                    .Skip(1).Take(1);

                // query is an expression that has yet to hit the database
                // var query = context.Ninjas; ***Disconnected Query***

                // ToList() is a LINQ Executio Method, which make a query execute against the database
                // var someninjas = query.ToList(); ***Connected Query***

                // Enumerate the query variable or query expression will be executed against the database
                // Avoid doing lots of work in an enumeration that is alos responsible for query execution
                // because it will open the database connection at the start and will keep it open till all the results have come back.
                //foreach (var ninja in context.Ninjas)
                //{
                //    Console.WriteLine(ninja.Name);
                //}

                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 18/10/2016 17:47:12 +01:00

            SELECT
                [Extent1].[Id] AS [Id],
                [Extent1].[Name] AS [Name],
                [Extent1].[ServedInOniwaban] AS [ServedInOniwaban],
                [Extent1].[ClanId] AS [ClanId],
                [Extent1].[DateOfBirth] AS [DateOfBirth]
                FROM [dbo].[Ninjas] AS [Extent1]
                WHERE [Extent1].[DateOfBirth] >= convert(datetime2, '2000-02-29 00:00:00.0000000', 121)
                ORDER BY [Extent1].[Name] ASC
                OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY


            -- Executing at 18/10/2016 17:47:12 +01:00

            -- Completed in 3 ms with result: SqlDataReader



            Leonardo
            Closed connection at 18/10/2016 17:47:12 +01:00
             */
            #endregion
        }

        public static void QueryAndUpdateNinja()
        {
            DbIntialise();
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault(); // This runs one transaction
                ninja.ServedInOniwaban = (!ninja.ServedInOniwaban); // This runs second transaction
                context.SaveChanges();
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 11:31:09 +01:00

            SELECT TOP (1)
                [c].[Id] AS [Id],
                [c].[Name] AS [Name],
                [c].[ServedInOniwaban] AS [ServedInOniwaban],
                [c].[ClanId] AS [ClanId],
                [c].[DateOfBirth] AS [DateOfBirth]
                FROM [dbo].[Ninjas] AS [c]


            -- Executing at 19/10/2016 11:31:09 +01:00

            -- Completed in 7 ms with result: SqlDataReader



            Closed connection at 19/10/2016 11:31:09 +01:00

            Opened connection at 19/10/2016 11:31:09 +01:00

            Started transaction at 19/10/2016 11:31:09 +01:00

            UPDATE [dbo].[Ninjas]
            SET [ServedInOniwaban] = @0
            WHERE ([Id] = @1)

            -- @0: 'True' (Type = Boolean)

            -- @1: '1' (Type = Int32)

            -- Executing at 19/10/2016 11:31:09 +01:00

            -- Completed in 1 ms with result: 1



            Committed transaction at 19/10/2016 11:31:09 +01:00

            Closed connection at 19/10/2016 11:31:09 +01:00
             */
            #endregion
        }

        public static void QueryAndUpdateNinjaDisconnected()
        {
            DbIntialise();
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
            }

            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                // EF will take note of this but will not know what has happend to it
                context.Ninjas.Attach(ninja);
                // Instruct EF that the state has change
                context.Entry(ninja).State = EntityState.Modified;
                // Thus it will do an update
                context.SaveChanges();
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 11:41:26 +01:00

            SELECT TOP (1)
                [c].[Id] AS [Id],
                [c].[Name] AS [Name],
                [c].[ServedInOniwaban] AS [ServedInOniwaban],
                [c].[ClanId] AS [ClanId],
                [c].[DateOfBirth] AS [DateOfBirth]
                FROM [dbo].[Ninjas] AS [c]


            -- Executing at 19/10/2016 11:41:26 +01:00

            -- Completed in 4 ms with result: SqlDataReader



            Closed connection at 19/10/2016 11:41:26 +01:00

            Opened connection at 19/10/2016 11:41:26 +01:00

            Started transaction at 19/10/2016 11:41:26 +01:00

            UPDATE [dbo].[Ninjas]
            SET [Name] = @0, [ServedInOniwaban] = @1, [ClanId] = @2, [DateOfBirth] = @3
            WHERE ([Id] = @4)

            -- @0: 'Raphael' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '29/02/2000 00:00:00' (Type = DateTime2)

            -- @4: '1' (Type = Int32)

            -- Executing at 19/10/2016 11:41:26 +01:00

            -- Completed in 3 ms with result: 1



            Committed transaction at 19/10/2016 11:41:26 +01:00

            Closed connection at 19/10/2016 11:41:26 +01:00
             */
            #endregion
        }

        public static void RetrieveDataWithFind()
        {
            DbIntialise();
            var keyval = 4;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                // First check if it has it in memory otherewise it will hit database to find it
                var ninja = context.Ninjas.Find(keyval); // If there's more than one result this will fail and return null
                Console.WriteLine("After Find#1:" + ninja.Name);

                // Since it has already found it in memory. EF will not goto the database
                var someNinja = context.Ninjas.Find(keyval);
                Console.WriteLine("After Find#2:" + someNinja.Name);
                ninja = null;
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 11:45:35 +01:00

            SELECT TOP (2)
                [Extent1].[Id] AS [Id],
                [Extent1].[Name] AS [Name],
                [Extent1].[ServedInOniwaban] AS [ServedInOniwaban],
                [Extent1].[ClanId] AS [ClanId],
                [Extent1].[DateOfBirth] AS [DateOfBirth]
                FROM [dbo].[Ninjas] AS [Extent1]
                WHERE [Extent1].[Id] = @p0


            -- p0: '4' (Type = Int32)

            -- Executing at 19/10/2016 11:45:35 +01:00

            -- Completed in 7 ms with result: SqlDataReader



            Closed connection at 19/10/2016 11:45:35 +01:00

            After Find#1:Donatello
            After Find#2:Donatello
             */
            #endregion
        }

        public static void RetrieveDataWithStoredProc()
        {
            DbIntialise();

            //CREATE PROCEDURE GetOldNinjas AS
            //SELECT Id, Name, ServedInOniwaban, ClanId, DateOfBirth
            //FROM Ninjas
            //WHERE DateOfBirth = '2/29/2000 00:00:00';
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                // the result of SP must match the Ninjas properties
                var ninjas = context.Ninjas.SqlQuery("exec GetOldNinjas");
                // Below loop is forcing the query to be executed in DB
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 12:04:58 +01:00

            exec GetOldNinjas


            -- Executing at 19/10/2016 12:04:58 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            Raphael
            Leonardo
            Michelangelo
            Donatello
            Closed connection at 19/10/2016 12:04:58 +01:00
             */
            #endregion
        }

        public static void DeleteNinja()
        {
            DbIntialise();
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
                //context.Ninjas.Remove(ninja);
                //context.SaveChanges();
            }
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Attach(ninja);
                //context.Ninjas.Remove(ninja);
                context.Entry(ninja).State = EntityState.Deleted;
                context.SaveChanges();
            }
            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 14:08:14 +01:00

            SELECT TOP (1)
                [c].[Id] AS [Id],
                [c].[Name] AS [Name],
                [c].[ServedInOniwaban] AS [ServedInOniwaban],
                [c].[ClanId] AS [ClanId],
                [c].[DateOfBirth] AS [DateOfBirth]
                FROM [dbo].[Ninjas] AS [c]


            -- Executing at 19/10/2016 14:08:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            Closed connection at 19/10/2016 14:08:14 +01:00

            Opened connection at 19/10/2016 14:08:14 +01:00

            Started transaction at 19/10/2016 14:08:14 +01:00

            DELETE [dbo].[Ninjas]
            WHERE ([Id] = @0)


            -- @0: '2' (Type = Int32)

            -- Executing at 19/10/2016 14:08:14 +01:00

            -- Completed in 0 ms with result: 1



            Committed transaction at 19/10/2016 14:08:14 +01:00

            Closed connection at 19/10/2016 14:08:14 +01:00
             */
            #endregion
        }

        public static void DeleteNinjaWithKeyValue()
        {
            DbIntialise();
            var keyval = 1;
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.Find(keyval); // DB round trip #1
                context.Ninjas.Remove(ninja);
                context.SaveChanges(); // DB round trip #2
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 14:18:11 +01:00

            SELECT TOP (2)
                [Extent1].[Id] AS [Id],
                [Extent1].[Name] AS [Name],
                [Extent1].[ServedInOniwaban] AS [ServedInOniwaban],
                [Extent1].[ClanId] AS [ClanId],
                [Extent1].[DateOfBirth] AS [DateOfBirth]
                FROM [dbo].[Ninjas] AS [Extent1]
                WHERE [Extent1].[Id] = @p0


            -- p0: '1' (Type = Int32)

            -- Executing at 19/10/2016 14:18:11 +01:00

            -- Completed in 7 ms with result: SqlDataReader



            Closed connection at 19/10/2016 14:18:11 +01:00

            Opened connection at 19/10/2016 14:18:11 +01:00

            Started transaction at 19/10/2016 14:18:11 +01:00

            DELETE [dbo].[Ninjas]
            WHERE ([Id] = @0)


            -- @0: '1' (Type = Int32)

            -- Executing at 19/10/2016 14:18:11 +01:00

            -- Completed in 2 ms with result: 1



            Committed transaction at 19/10/2016 14:18:11 +01:00

            Closed connection at 19/10/2016 14:18:11 +01:00
             */
            #endregion
        }

        public static void DeleteNinjaViaStoredProcedure()
        {
            DbIntialise();

            //CREATE PROCEDURE DeleteNinjaViaId
            //@ID int
            //AS
            //DELETE FROM Ninjas WHERE Id = @ID;

            var keyval = 3;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Database.ExecuteSqlCommand("exec DeleteNinjaViaId {0}", keyval);
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 14:28:18 +01:00

            Started transaction at 19/10/2016 14:28:18 +01:00

            exec DeleteNinjaViaId @p0


            -- p0: '3' (Type = Int32, IsNullable = false)

            -- Executing at 19/10/2016 14:28:18 +01:00

            -- Completed in 3 ms with result: 1



            Committed transaction at 19/10/2016 14:28:18 +01:00

            Closed connection at 19/10/2016 14:28:18 +01:00
             */
            #endregion
        }

        public static void InsertNinjaWithEquipment()
        {
            DbIntialise();
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = new Ninja
                {
                    Name = "Kacy Catanzaro",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1990, 1, 14),
                    ClanId = 1
                };
                var muscles = new NinjaEquipment
                {
                    Name = "Muscles",
                    Type = EquipmentType.Tool,

                };
                var spunk = new NinjaEquipment
                {
                    Name = "Spunk",
                    Type = EquipmentType.Weapon
                };

                ninja.EquipmentOwned.Add(muscles);
                ninja.EquipmentOwned.Add(spunk);
                context.Ninjas.Add(ninja);
                // three inserts in one transaction
                context.SaveChanges();
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 14:36:22 +01:00

            Started transaction at 19/10/2016 14:36:22 +01:00

            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Kacy Catanzaro' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '14/01/1990 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 14:36:22 +01:00

            -- Completed in 3 ms with result: SqlDataReader



            INSERT [dbo].[NinjaEquipments]([Name], [Type], [Ninja_Id])
            VALUES (@0, @1, @2)
            SELECT [Id]
            FROM [dbo].[NinjaEquipments]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Muscles' (Type = String, Size = -1)

            -- @1: '1' (Type = Int32)

            -- @2: '5' (Type = Int32)

            -- Executing at 19/10/2016 14:36:22 +01:00

            -- Completed in 1 ms with result: SqlDataReader



            INSERT [dbo].[NinjaEquipments]([Name], [Type], [Ninja_Id])
            VALUES (@0, @1, @2)
            SELECT [Id]
            FROM [dbo].[NinjaEquipments]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Spunk' (Type = String, Size = -1)

            -- @1: '2' (Type = Int32)

            -- @2: '5' (Type = Int32)

            -- Executing at 19/10/2016 14:36:22 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            Committed transaction at 19/10/2016 14:36:22 +01:00

            Closed connection at 19/10/2016 14:36:22 +01:00
             */
            #endregion
        }

        public static void SimpleNinjaGraphQueryWithEagerLoading()
        {
            DbIntialise();
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                // This is Eager Loading, which brings back all the data from DB in one call
                var ninja = context.Ninjas.Include(n => n.EquipmentOwned).FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                Console.WriteLine("Ninja Retrieved using Explicit Loading: " + ninja.Name);
                Console.WriteLine("Number Of Equipment: " + ninja.EquipmentOwned.Count);
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 15:01:10 +01:00

            SELECT
                [Project1].[Id] AS [Id],
                [Project1].[Name] AS [Name],
                [Project1].[ServedInOniwaban] AS [ServedInOniwaban],
                [Project1].[ClanId] AS [ClanId],
                [Project1].[DateOfBirth] AS [DateOfBirth],
                [Project1].[C1] AS [C1],
                [Project1].[Id1] AS [Id1],
                [Project1].[Name1] AS [Name1],
                [Project1].[Type] AS [Type],
                [Project1].[Ninja_Id] AS [Ninja_Id]
                FROM ( SELECT
                    [Limit1].[Id] AS [Id],
                    [Limit1].[Name] AS [Name],
                    [Limit1].[ServedInOniwaban] AS [ServedInOniwaban],
                    [Limit1].[ClanId] AS [ClanId],
                    [Limit1].[DateOfBirth] AS [DateOfBirth],
                    [Extent2].[Id] AS [Id1],
                    [Extent2].[Name] AS [Name1],
                    [Extent2].[Type] AS [Type],
                    [Extent2].[Ninja_Id] AS [Ninja_Id],
                    CASE WHEN ([Extent2].[Id] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
                    FROM   (SELECT TOP (1) [Extent1].[Id] AS [Id], [Extent1].[Name] AS [Name], [Extent1].[ServedInOniwaban] AS [ServedInOniwaban], [Extent1].[ClanId] AS [ClanId], [Extent1].[DateOfBirth] AS [DateOfBirth]
                        FROM [dbo].[Ninjas] AS [Extent1]
                        WHERE [Extent1].[Name] LIKE N'Kacy%' ) AS [Limit1]
                    LEFT OUTER JOIN [dbo].[NinjaEquipments] AS [Extent2] ON [Limit1].[Id] = [Extent2].[Ninja_Id]
                )  AS [Project1]
                ORDER BY [Project1].[Id] ASC, [Project1].[C1] ASC


            -- Executing at 19/10/2016 15:01:10 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            Closed connection at 19/10/2016 15:01:10 +01:00

            Ninja Retrieved using Explicit Loading: Kacy Catanzaro
            Number Of Equipment: 2
             */
            #endregion
        }
    }
}
