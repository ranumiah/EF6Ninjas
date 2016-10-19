using NinjaDomain.Classes;
using NinjaDomain.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NinjaDomain.DataModel
{
    public class DbHelper
    {
        public static void NewDbWithSeed()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                if (context.Ninjas.Any())
                {
                    return;
                }
                var vtClan = context.Clans.Add(new Clan { ClanName = "Vermont Clan" });
                var turtleClan = context.Clans.Add(new Clan { ClanName = "Turtles" });
                var amClan = context.Clans.Add(new Clan { ClanName = "American Ninja Warriors" });
                var footClan = context.Clans.Add(new Clan { ClanName = "Foot Clan" });

                context.Clans.Add(new Clan { ClanName = "Vermont Clan" });
                var j = new Ninja
                {
                    Name = "JulieSan",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Clan = vtClan

                };
                var s = new Ninja
                {
                    Name = "SampsonSan",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(2008, 1, 28),
                    ClanId = 1

                };
                var l = new Ninja
                {
                    Name = "Leonardo",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1984, 1, 1),
                    Clan = turtleClan
                };
                var r = new Ninja
                {
                    Name = "Raphael",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1985, 1, 1),
                    Clan = turtleClan
                };
                var shredder = new Ninja
                {
                    Name = "Shredder",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(2000, 2, 29),
                    Clan = footClan
                };
                var karai = new Ninja
                {
                    Name = "Karai",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(2000, 2, 29),
                    Clan = footClan
                };
                var Kitsune = new Ninja
                {
                    Name = "Kitsune",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(2000, 2, 29),
                    Clan = footClan
                };
                var krang = new Ninja
                {
                    Name = "Krang",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(2000, 2, 29),
                    Clan = footClan
                };

                context.Ninjas.AddRange(new List<Ninja> { j, s, l, r, shredder, karai, Kitsune, krang });

                var ninja = new Ninja
                {
                    Name = "Kacy Catanzaro",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1990, 1, 14),
                    Clan = amClan
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

                context.SaveChanges();
                context.Database.ExecuteSqlCommand(
                  @"CREATE PROCEDURE GetOldNinjas
                    AS  SELECT * FROM Ninjas WHERE DateOfBirth<='1/1/1980'");

                context.Database.ExecuteSqlCommand(
                   @"CREATE PROCEDURE DeleteNinjaViaId
                     @Id int
                     AS
                     DELETE from Ninjas Where Id = @id
                     RETURN @@rowcount");
            }

            #region SQL Statement EF EXEC
            /*
            Opened connection at 19/10/2016 16:22:14 +01:00

            Started transaction at 19/10/2016 16:22:14 +01:00

            CREATE TABLE [dbo].[Clans] (
                [Id] [int] NOT NULL IDENTITY,
                [ClanName] [nvarchar](max),
                CONSTRAINT [PK_dbo.Clans] PRIMARY KEY ([Id])
            )


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 6 ms with result: -1



            CREATE TABLE [dbo].[Ninjas] (
                [Id] [int] NOT NULL IDENTITY,
                [Name] [nvarchar](max),
                [ServedInOniwaban] [bit] NOT NULL,
                [ClanId] [int] NOT NULL,
                CONSTRAINT [PK_dbo.Ninjas] PRIMARY KEY ([Id])
            )


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: -1



            CREATE INDEX [IX_ClanId] ON [dbo].[Ninjas]([ClanId])


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: -1



            CREATE TABLE [dbo].[NinjaEquipments] (
                [Id] [int] NOT NULL IDENTITY,
                [Name] [nvarchar](max),
                [Type] [int] NOT NULL,
                [Ninja_Id] [int] NOT NULL,
                CONSTRAINT [PK_dbo.NinjaEquipments] PRIMARY KEY ([Id])
            )


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: -1



            CREATE INDEX [IX_Ninja_Id] ON [dbo].[NinjaEquipments]([Ninja_Id])


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: -1



            ALTER TABLE [dbo].[Ninjas] ADD CONSTRAINT [FK_dbo.Ninjas_dbo.Clans_ClanId] FOREIGN KEY ([ClanId]) REFERENCES [dbo].[Clans] ([Id]) ON DELETE CASCADE


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: -1



            ALTER TABLE [dbo].[NinjaEquipments] ADD CONSTRAINT [FK_dbo.NinjaEquipments_dbo.Ninjas_Ninja_Id] FOREIGN KEY ([Ninja_Id]) REFERENCES [dbo].[Ninjas] ([Id]) ON DELETE CASCADE


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: -1



            CREATE TABLE [dbo].[__MigrationHistory] (
                [MigrationId] [nvarchar](150) NOT NULL,
                [ContextKey] [nvarchar](300) NOT NULL,
                [Model] [varbinary](max) NOT NULL,
                [ProductVersion] [nvarchar](32) NOT NULL,
                CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
            )


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: -1



            INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
            VALUES (N'201610121329508_Initial', N'NinjaDomain.DataModel.Migrations.Configuration',  0x1F8B0800000000000400ED5ACD6EE33610BE17E83B083AB54536CACFA50DEC5D649DA408BA8E177176DB5B404B63872D4569452A6BA3E893F5D047EA2B74A87F91A22D3B3F0D168B1C62539CE170E69BE1F093FFFDFB9FC19B65C89C7B48048DF8D03DDC3F701DE07E1450BE18BAA99CBFFAD17DF3FADB6F06E741B8743E96F38ED53C94E462E8DE49199F789EF0EF2024623FA47E1289682EF7FD28F44810794707073F7987871EA00A177539CEE03AE59286907DC1AFA388FB10CB94B071140013C5383E99665A9D2B128288890F43F78AF2DFC9591412CAF7CF88249984EB9C324AD09829B0B9EB10CE2349249A7AF241C05426115F4C631C20EC661503CE9B1326A0D8C2493DBDEF6E0E8ED46EBC5AB054E5A742A26DDB293C3C2EDCE3E9E23B39D9ADDC870E3C4747CB95DA75E6C4A13B6204D5EA0B9D8C58A226B5FD8B738500A1FEF33DA7E3C95E0509448EFADB734629936902430EA94C08DB73DEA73346FD5F607513FD017CC853C69A16A28DF8AC358043EF93288644AEAE615ED87D19B88ED796F374C14AAC2193EFEA92CBE323D7B9C2C5C98C4105808607A6324AE067E0901009C17B2225245CE980CC85C6EADA5ACA47EA53B922A20E73C875C664F90EF842DE0D5DFCE83A17740941395258F181534C391492490AC64257E49E2E321BB525B38008D7B906963D167734CE53603F7B749BC7FA2289C2EB889502D9E8ED0D491620D1D8C878348DD2C4D7CC18783590D6C22BD3B32DBEB2B1AF005B0FB0A70197B6C814927B082EF984D3CF64A6D0932FF8364294A8AFC6063767C56627F5057C8EE75DE05E62BA03EE6526F435E2FC534AE3106336F9CC21B09B53CDBB2D7242334C7BDE9D91FAA487E766A571A724ADA4BF66EB0BC856A5BE5A4401AF0A4FFE64E7442B10FB58D0EECC3E1BFEFB413B0D1BC0D6B67D292E1859D45DDE763857BA45DB938F0A760C7100095B21249A606C47660CE10C9232CC587C5DE72361297E3934A2D89AFB2B9058F58DC5ECA3F5B327A9FC0C24A9A61F9BEECF1DDD1C3C1522F269E6C9265CF2F2DB5EEC9C078EBD16D7B82D603446FFD1183D86211FBA3F18B677AAABEA66AD2E3F08DADA0E5DBDA84CF8193090E09CFA79AB3E22C227819926E885A03D82750812550808C3BB8BC060532ECDA245B94F63C2AC366B123D0B9DB2A8D2AD3F398318B8AA5156BFF759B43CB6CD852BFD9A8B367964E03560D3034D7A89590B046BBDD110D638FBB6849AF5B0DE80E1C7439DD581798544A74B747995D999356A10965D273D5E8B8B22288AA346DFBE523A05D90004DE34EA6ADCCA34C3776DE1F29E6248172EDB20DE885AB786C6044D55C3659A3945B3D89860B6927AE8D656B3CAEA7ABF46F6ACAD5F0D0585B77540B477D377A7C6616DD9F3DA8CEB9F738D6D58E3D23FBF367A758D57CAE6A14A8D9A56F2725EA9E49F3C0B0135189338C673BA41481523CE3467A346AFA6DB733461AEC3F345075553595BAD848D285980F61497464B2F6822A462C16644353AA32034A6B50A8125D1CAA59AB96E06AC4CBD72B6FADCC099CEC9ED77E550EDC10BDC940A78B63FD0C06F8A655C206124E9E8E947114B436E3F2EEDD23569D3D4518F9A9A069E66BF71421A8E32CA7ADBEBBD625280FFE141E9CCED1E51B1C83D4D58CC90D8C261D360F2184D6DE6D3ED20A3EFCED62EFD6F70A92BEF2321C6AAB02F74D62878A918CA2F934D0DF9C8F347B97DC4755406E38CDF2EA8A5D47691536778176F6039CB4DAFF58A7AAEA3FB32D2306047DBAC77A29D1169B74A6F55CC501B1D8B3EA5025AD5B9681DCAA0E81636BF4733DA877C8AEBA0EDF73450ADC374252484196AF6A79FD888D1AC972B278C09A7731032E736DCA383C323ED3DDCCB7927E60911B01E2FC69E9D89A4CAA31BB9C61D58F72601C9EF49E2DF91E4BB902CBF6F6A3349C62D5FF47C19FEDAD157FD5F9FCCA87CE0AB13DA49D85FF2009643F7CF4CE4C4B9FCED3697DA73260966E88973E0FCB561E15DDF1E7C8DBC958ACF2CDDD690EA98DB2EDEA5DC23447C275E37A7519E937BD598835D78E49DE85BCB75F66918DB2F91A57D4EB6740DC3F4205A7877E2FFD9A0B3EEAA66AEB8AEBD7E74147553D52691B5998BB652D179173B7483598481CE6B60379DDAC952DB49EA2EC5164AB253F3362CB675AD6A8EB9E85351DD4D6FD7FCDC4642D7A46E5F389FBDD9E0B535C57E6B7E12C2DABCE6615A367E5489A541D045AD42FDC49283DF4AC86ACE259F476565D02C2AA768DDCA182409305B4F1349E7C497F8D80721B25F3914AF92CFC359D609A7324E256E19C2196BFD6A42D59775EB67AC7CDBE6C124CE7E8EF0185B4033296E0126FC6D4A5950D97DD1D1305954A8C255F4A22A9652F5A48B55A5E92AE23D1515EEABEAED0D8431436562C2A7E41E76B1ED838077B020FEAABCADDB956C0E44DBED83334A16090945A1A396C7AF88E1205CBEFE0FAF5122025B2C0000 , N'6.1.3-40302')

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: 1



            Committed transaction at 19/10/2016 16:22:14 +01:00

            Opened connection at 19/10/2016 16:22:14 +01:00

            Started transaction at 19/10/2016 16:22:14 +01:00

            ALTER TABLE [dbo].[Ninjas] ADD [DateOfBirth] [datetime] NOT NULL DEFAULT '1900-01-01T00:00:00.000'


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: -1



            INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
            VALUES (N'201610121407468_AddBirthdayToNinja', N'NinjaDomain.DataModel.Migrations.Configuration',  0x1F8B0800000000000400ED5ACD6EE33610BE17E83B083AB545364AB29736B07791759222E8265EC4D96D6F012D8D1DB614A58A54D646D127EBA18FD457E850FF224559767E102C1639C4E6CF7038F3CD70F8D1FFFDF3EFE8ED2A64CE3D2482467CEC1EEE1FB80E703F0A285F8EDD542E5EFDE8BE7DF3ED37A3B3205C399FCA71AFD5389CC9C5D8BD93323EF63CE1DF4148C47E48FD2412D142EEFB51E89120F28E0E0E7EF20E0F3D40112ECA729CD175CA250D21FB825F2711F7219629619751004C14EDD833CBA43A57240411131FC6EE15E5BF93D3282494EF9F1249B219AE73C228416566C016AE43388F2491A8EAF147013399447C398BB181B09B750C386E419880620BC7F5F0A1BB393852BBF1EA89A5283F151275DB4EE0E1EBC23C9E3E7D2723BB95F9D080676868B956BBCE8C3876278CA0587DA1E3094BD4A0B67D71AC1020D47FBEE774F4EC559040E4A8BF3D679232992630E690CA84B03DE7433A67D4FF05D637D11FC0C73C65ACA921EA887DAD066CFA90443124727D0D8B42EF8BC075BCF63C4F9F584D6BCCC97775C1E5EB23D7B9C2C5C99C410580860566324AE067E0901009C1072225245CC980CC84C6EADA5ACA46EA53B922A20E63C8752EC9EA3DF0A5BC1BBBF8D175CEE90A82B2A5D0E223A7187238492629180B5D917BBACC74D496CC1C225CE71A58D62DEE689C87C07ED6759BFBFA3C89C2EB889513B2D6DB1B922C41A2B291D1358BD2C4D7D4187935907AE195C9D9165F59DB5780F503EC69C0A52D3283E41E820B3EE5F433992BF4E40BBE8B1025EAABB1C1CD51B1D948FD3230CBC374F18E26F2AE14A49A6EA8B2C72659D6E0C9636397D029E3A32374CAA81AAAC4D99F298D43F4FFF43387C0AE4E35EEB6882F4D31ADBF3BBAF5410F8FF34AE24E015FCDFE1AF92F20F295F86A1105BCCA3D79CFCE815620F6B1A0DD197D36FC0F83761A3680AD6DFB429C33B2AC2BC6ED70AE648BB6251F15ECE8E20012B6464834C1D8F6CC258473484A376322779D4F84A5F8E5D0F0626BECAF4062558316A38FFA474F53F91948520D7F6D9A3F3774B3F14488C8A799259B70C9D36F7BB1331E38F65C5CE3B680D125DA8FC6683174F9D8FDC1D0BD535C95376B71F941D09676E8EA4965CA4F818104E7C4CFCBFE09113E09CC30412B04ED16CC4390A8444018DE83043A9B7269262DCA7D1A1366D5599B3130D1298D2AD97ACF29C4C0558EB2DA7DC8A26509602E5CC9D74CB4C92223AF019B0168D2534C2F10ACF9464358E3ECDB126AD6C37A03861F0F755603E619128D2ED1E4556467DAA84658759DF478C52E92A0288E1A7DFB4AE80C640310786BA9B3712BD20CDBB52797771E637661B20DD31B5EEB96D018A0896A984C53A728161B03CC5252775D6F36ABB4AEF76B444F6FFE6A0828ACAD03A2BD9BA13B350E6BCB9E7B236E78CC35B661F5CBF0F8DA68D51EAB94C543151A3545E5E51C55C9657916326B7449E218CFE906B955B438B39CD99ABC9A6DCFF784B90CCF171DB44FA56DB51216A264095A2F2E8D9A9ED34448C5A8CD892A742641680C6B25024BA0954B3563DD7458197AE568F5B981339DDFDBEF8AA1DA82E7B829E5F06C7FA081DF9C96F18A8491A4A3A69F442C0DB9FDB8B4CFAE09A0A68CBAD59434F234FD8D13D2309491D6DB561FE49302FC0F774A676C0FF08A65DED3B8C57489CD1D36092627D29466F66E07197D77B672C92EA5C58F3445B53A5E0CFCEA4CFE4808B40A1C0AC51E012F1593F9E5B429216F797E2FB78FCC8E4C63D40CDB39B59CB59DE7544DD0C543586A03D36A83BC9ECBE8BEDC3414D85137EB1D6B6744DAB5D24B1FD3D54605A40FA9805655425AC5332AAA8FCD6F7C4639920F711DD4FD9E06AA1499AD85843043CDFEEC4F366134AB0DCB019784D30508997325EED1C1E191F646F872DEEB3C210236E0D1EED9994DAA2CBA91BBDCE145A04968F27B92F87724F92E24ABEF9BD24CD272CB47A82FC35E3BDA6AF8D3CE9CCA073EEBD0CE07800B1EC06AECFE954D39762E7EBBCD67ED39D30423F4D83970FE7E8CB7A0009BE4E6B7A05D5F36BEA2C8FA4C9069BAAD22D591B91D76CA795BA0C7E6F19D38E79CE2794E5E58633576E1B877A2962D57EDA76193BF4406F93999DC1EF6EB4194F5EE8F12CF069DBE6B9FB9625FA9FEE828EAA6D14D926D334F6EA5C9F38A184FBF79848ECE736037D5DBC9A0DB09F42EC116BAB453F2360CBB75AD6A8CB9E853D1F04D6BD7DCE146B2D9A4955F38D7BE59E1DE9C62BF813F09996E5E19312C1B3F1EC5D420E8B216A17E4ACAC16F056435E6822FA23233681A9543B46AE51224C1FA929C24922E882FB1DB0721B25F6014CFDC67E13CABAA5319A712B70CE19CB57ED1A1F24BDFFAD98B415BE7D134CE7E2AF1185B4035A92A91A7FC5D4A5950E97DDE51305944A8C455D4A2CA9752D5A4CB7525E92AE2030515E6ABF2ED0D8431436162CA67E41E76D1EDA380F7B024FEBABCF9DB856C7644DBECA3534A9609094521A39E8F5F11C341B87AF33F56A33627432D0000 , N'6.1.3-40302')

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: 1



            Committed transaction at 19/10/2016 16:22:14 +01:00

            Opened connection at 19/10/2016 16:22:14 +01:00

            SELECT
                CASE WHEN ( EXISTS (SELECT
                    1 AS [C1]
                    FROM [dbo].[Ninjas] AS [Extent1]
                )) THEN cast(1 as bit) ELSE cast(0 as bit) END AS [C1]
                FROM  ( SELECT 1 AS X ) AS [SingleRowTable1]


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: SqlDataReader



            Closed connection at 19/10/2016 16:22:14 +01:00

            Opened connection at 19/10/2016 16:22:14 +01:00

            Started transaction at 19/10/2016 16:22:14 +01:00

            INSERT [dbo].[Clans]([ClanName])
            VALUES (@0)
            SELECT [Id]
            FROM [dbo].[Clans]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Vermont Clan' (Type = String, Size = -1)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 2 ms with result: SqlDataReader



            INSERT [dbo].[Clans]([ClanName])
            VALUES (@0)
            SELECT [Id]
            FROM [dbo].[Clans]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Turtles' (Type = String, Size = -1)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Clans]([ClanName])
            VALUES (@0)
            SELECT [Id]
            FROM [dbo].[Clans]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Foot Clan' (Type = String, Size = -1)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Clans]([ClanName])
            VALUES (@0)
            SELECT [Id]
            FROM [dbo].[Clans]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'American Ninja Warriors' (Type = String, Size = -1)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Clans]([ClanName])
            VALUES (@0)
            SELECT [Id]
            FROM [dbo].[Clans]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Vermont Clan' (Type = String, Size = -1)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Kacy Catanzaro' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '4' (Type = Int32)

            -- @3: '14/01/1990 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'JulieSan' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '01/01/1980 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'SampsonSan' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '1' (Type = Int32)

            -- @3: '28/01/2008 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Leonardo' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '2' (Type = Int32)

            -- @3: '01/01/1984 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Raphael' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '2' (Type = Int32)

            -- @3: '01/01/1985 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Shredder' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '3' (Type = Int32)

            -- @3: '29/02/2000 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Karai' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '3' (Type = Int32)

            -- @3: '29/02/2000 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Kitsune' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '3' (Type = Int32)

            -- @3: '29/02/2000 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[Ninjas]([Name], [ServedInOniwaban], [ClanId], [DateOfBirth])
            VALUES (@0, @1, @2, @3)
            SELECT [Id]
            FROM [dbo].[Ninjas]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Krang' (Type = String, Size = -1)

            -- @1: 'False' (Type = Boolean)

            -- @2: '3' (Type = Int32)

            -- @3: '29/02/2000 00:00:00' (Type = DateTime2)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            INSERT [dbo].[NinjaEquipments]([Name], [Type], [Ninja_Id])
            VALUES (@0, @1, @2)
            SELECT [Id]
            FROM [dbo].[NinjaEquipments]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Muscles' (Type = String, Size = -1)

            -- @1: '1' (Type = Int32)

            -- @2: '1' (Type = Int32)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 1 ms with result: SqlDataReader



            INSERT [dbo].[NinjaEquipments]([Name], [Type], [Ninja_Id])
            VALUES (@0, @1, @2)
            SELECT [Id]
            FROM [dbo].[NinjaEquipments]
            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()


            -- @0: 'Spunk' (Type = String, Size = -1)

            -- @1: '2' (Type = Int32)

            -- @2: '1' (Type = Int32)

            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: SqlDataReader



            Committed transaction at 19/10/2016 16:22:14 +01:00

            Closed connection at 19/10/2016 16:22:14 +01:00

            Opened connection at 19/10/2016 16:22:14 +01:00

            Started transaction at 19/10/2016 16:22:14 +01:00

            CREATE PROCEDURE GetOldNinjas
                                AS  SELECT * FROM Ninjas WHERE DateOfBirth<='1/1/1980'


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: -1



            Committed transaction at 19/10/2016 16:22:14 +01:00

            Closed connection at 19/10/2016 16:22:14 +01:00

            Opened connection at 19/10/2016 16:22:14 +01:00

            Started transaction at 19/10/2016 16:22:14 +01:00

            CREATE PROCEDURE DeleteNinjaViaId
                                 @Id int
                                 AS
                                 DELETE from Ninjas Where Id = @id
                                 RETURN @@rowcount


            -- Executing at 19/10/2016 16:22:14 +01:00

            -- Completed in 0 ms with result: -1



            Committed transaction at 19/10/2016 16:22:14 +01:00

            Closed connection at 19/10/2016 16:22:14 +01:00
             */
            #endregion
        }
    }
}
