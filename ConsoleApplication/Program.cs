using NinjaDomain.DataModel;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Single Item");
            Repository.InsertClan();
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();

            Console.WriteLine("Insert Multiple Items");
            Repository.InsertMultipleNinjas();
            Console.ReadLine();

            Console.WriteLine("Run Simple Query");
            Repository.SimpleNinjaQueries();
            Console.ReadLine();

            Console.WriteLine("Run Query and Update");
            Repository.QueryAndUpdateNinja();
            Console.ReadLine();

            Console.WriteLine("Run Query and Update In Disconnect Mode");
            Repository.QueryAndUpdateNinjaDisconnected();
            Console.ReadLine();

            Console.WriteLine("Run Retrieve Data With Find");
            Repository.RetrieveDataWithFind();
            Console.ReadLine();

            Console.WriteLine("Run Retrieve Data With Stored Procedure");
            Repository.RetrieveDataWithStoredProc();
            Console.ReadLine();

            Console.WriteLine("Run Delete");
            Repository.DeleteNinja();
            Console.ReadLine();

            Console.WriteLine("Run Delete With Key Value");
            Repository.DeleteNinjaWithKeyValue();
            Console.ReadLine();

            Console.WriteLine("Run Delete With Stored Procedure");
            Repository.DeleteNinjaViaStoredProcedure();
            Console.ReadLine();

            Console.WriteLine("Run Insert Related Items");
            Repository.InsertNinjaWithEquipment();
            Console.ReadLine();

            Console.WriteLine("Run Query with Related Item using Eager Loading");
            Repository.SimpleNinjaGraphQueryWithEagerLoading();

            Console.WriteLine("Press Any Key to Exit");
            Console.ReadLine();
        }
    }
}
