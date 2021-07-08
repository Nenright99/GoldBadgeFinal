using ChallengeOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneInterface
{
    class ProgramUI
    {
        public void Run()
        {
            DisplayMenu();
        }
        protected readonly ItemRepository _itemDirectory = new ItemRepository();
        public void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "What can I help you with today? \n" +
                    "1. Add a menu item \n" +
                    "2. List all menu items \n" +
                    "3. Remove a menu item \n" +
                    "4. Exit\n" +
                    "Enter the number of the option you would like to select");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewItem();
                        break;
                    case "2":
                        ListAllMenuItems();
                        break;
                    case "3":
                        RemoveCurrentItem();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option 1-4");
                        ReduceRed();
                        break;
                }
            }
        }

        public void AddNewItem()
        {
            Console.Clear();
            Console.WriteLine("What is the item number?");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the item name?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the item description?");
            string description = Console.ReadLine();
            List<string> ingredients = new List<string>();
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Add an ingredient? y/n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "y":
                        Console.WriteLine("What is the ingredient?");
                        string ingredient = Console.ReadLine();
                        ingredients.Add(ingredient);
                        break;
                    case "n":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("What is the price?");
            decimal price = decimal.Parse(Console.ReadLine());
            Items item = new Items(number, name, description, ingredients, price);
            _itemDirectory.AddItem(item);
            ReduceRed();
        }
        public void ListAllMenuItems()
        {
            foreach(Items item in _itemDirectory.GetDirectory())
            {
                Console.WriteLine(item.Number.ToString() + " " + item.Name + " $" + item.Price.ToString());
            }
            ReduceRed();
        }
        public void RemoveCurrentItem()
        {
            Console.WriteLine("Enter the number of the item you want to remove: ");
            int itemNumber = int.Parse(Console.ReadLine());
            _itemDirectory.RemoveItem(_itemDirectory.GetByNumber(itemNumber));
            ReduceRed();
        }
        private void ReduceRed()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
