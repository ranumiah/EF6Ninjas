using NinjaDomain.DataModel;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DbHelper.NewDbWithSeed();
            //InsertExamples();
            //QueryAndUpdateExamples();
            //DeleteExamples();
            //GraphQueryExample();

            Console.WriteLine("Press Any Key to Exit");
            Console.ReadLine();
        }

        static void InsertExamples()
        {
            Console.WriteLine("Insert Single Item");
            Repository.InsertClan();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Insert Multiple Items");
            Repository.InsertMultipleNinjas();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();
        }

        private static void QueryAndUpdateExamples()
        {
            Console.WriteLine("Run Simple Query");
            Repository.SimpleNinjaQueries();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Query and Update");
            Repository.QueryAndUpdateNinja();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Query and Update In Disconnect Mode");
            Repository.QueryAndUpdateNinjaDisconnected();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Retrieve Data With Find");
            Repository.RetrieveDataWithFind();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Retrieve Data With Stored Procedure");
            Repository.RetrieveDataWithStoredProc();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();
        }

        private static void DeleteExamples()
        {
            Console.WriteLine("Run Delete");
            Repository.DeleteNinja();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Delete With Key Value");
            Repository.DeleteNinjaWithKeyValue();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Delete With Stored Procedure");
            Repository.DeleteNinjaViaStoredProcedure();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();
        }

        private static void GraphQueryExample()
        {
            Console.WriteLine("Run Insert Related Items");
            Repository.InsertNinjaWithEquipment();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Query with Related Item using Eager Loading");
            Repository.SimpleNinjaGraphQueryWithEagerLoading();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Query with Related Item using Explict Loading");
            Repository.SimpleNinjaGraphQueryWithExplicitLoading();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Query with Related Item using Lazy Loading");
            Repository.SimpleNinjaGraphQueryWithLazyoading();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Run Query with Related Item using Projection");
            Repository.SimpleProjectionQuery();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();
        }
    }
}
