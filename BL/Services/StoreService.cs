using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    class StoreService
    {
        private readonly IUnitOfWork unitOfWork;

        public StoreService()
        {
            unitOfWork = new StoreUnitOfWork();
        }

        public static bool ExitProgram { get; private set; } = false;

        public static void ChooseCommande()
        {
            Console.WriteLine("Choose commande(Write number from 1 to)");
            Console.WriteLine("1. Show inventory");
            Console.WriteLine("2. Add items");
            Console.WriteLine("3. Delete car(by id)");
            Console.WriteLine("4. Output last minute transaction history");
            Console.WriteLine("5. Show parking profit");
            Console.WriteLine("6. Show last minute profit");
            Console.WriteLine("7. Output Transactions.log");
            Console.WriteLine("8. Show car balance(by id)");
            Console.WriteLine("9. Show number of free places");
            Console.WriteLine("10. Show number of cars in a parking lot");
            Console.WriteLine("11. Exit");
            int commande = Int32.Parse(Console.ReadLine());
            switch (commande)
            {
                
                default:
                    throw new InvalidOperationException("Unknown command");
            }
        }
    }
}
