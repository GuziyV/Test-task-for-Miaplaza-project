using DAL;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class StoreService
    {
        private readonly IRepository<StoreItem, string> repository;

        public StoreService()
        {
            repository = new StoreItemRepository();
        }

        public bool ExitProgram { get; private set; } = false;

        public void ChooseCommande()
        {
            Console.WriteLine("Choose commande");
            Console.WriteLine("1. Show inventory(type 'inventory' or 1)");
            Console.WriteLine("2. Add product(type 'addproduct' or 2)");
            Console.WriteLine("3. Add items(type 'incoming' or 3)");
            Console.WriteLine("4. Sale products(type 'sale' or 4)");
            Console.WriteLine("5. Exit(type 'exit or 11')");
            string command = Console.ReadLine();
            switch (command)
            {
                case "1":
                case "inventory":
                    ShowInventory();
                    break;
                case "2":
                case "addproduct":
                    AddProduct();
                    break;
                case "3":
                case "incoming":
                    Incoming();
                    break;
                case "4":
                case "sale":
                    Sale();
                    break;
                case "5":
                case "exit":
                    Exit();
                    break;
                default:
                    throw new InvalidOperationException("Unknown command");
            }
        }

        private void Exit()
        {
            this.ExitProgram = true;
        }

        private void Sale()
        {
            Console.WriteLine("Enter a list of items sold and their quantity (blank line to finish):");
            string input;
            decimal sum = 0;
            while ((input = Console.ReadLine()) != string.Empty)
            {
                string[] itemComponents = input.Split(' ');
                string itemName = itemComponents[0].Trim(':');
                StoreItem old = repository.Get(itemName);
                if (old == null)
                {
                    throw new FormatException("Cant find item with this name, please add product first!");
                }
                else
                {
                    uint numOfItemsToRemove = uint.Parse(itemComponents[1]);
                    if (old.Count - numOfItemsToRemove < 0)
                    {
                        throw new InvalidOperationException($"Not enough {itemName} in store");
                    }
                    sum += old.Count * numOfItemsToRemove;
                    old.Count -= uint.Parse(itemComponents[1]);
                }
            }
            if(sum != 0)
            {
                Console.WriteLine($"Total: {sum}");
            }
        }

        private void AddProduct()
        {
            Console.WriteLine("Name? ");
            string name = Console.ReadLine();
            var item = repository.Get(name);
            if(item != null)
            {
                throw new InvalidOperationException("Item with this name aready exists!");
            }
            Console.WriteLine("Price? ");
            decimal price = Decimal.Parse(Console.ReadLine());

            StoreItem newItem = new StoreItem(name, price);
            repository.Create(newItem);          
        }

        private void Incoming()
        {
            Console.WriteLine("Enter a list of incoming items and their quantity (blank line to finish):");
            string input;
            while((input =  Console.ReadLine()) != string.Empty)
            {
                string[] itemComponents = input.Split(' ');
                string itemName = itemComponents[0].Trim(':');
                StoreItem old = repository.Get(itemName);
                if (old == null)
                {
                    throw new FormatException("Cant find item with this name, please add product first!");
                }
                else
                {
                    old.Count += uint.Parse(itemComponents[1]);
                }
            }
        }

        private void ShowInventory()
        {
            var allItems = repository.GetAll();
            if(allItems.Count == 0)
            {
                Console.WriteLine("Empty");
                return;
            }
            Console.WriteLine(String.Format("{0,-6} | {1,-9} | {2,-15}", "Count", "Item", "Price per item"));
            foreach(var item in allItems)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
