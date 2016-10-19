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

            Console.WriteLine("Press Any Key to Exit");
        }
    }
}
