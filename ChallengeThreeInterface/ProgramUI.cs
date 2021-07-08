using ChallengeThreeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeInterface
{
    class ProgramUI
    {
        public void Run()
        {
            DisplayMenu();
        }
        protected readonly BadgeRepository _badgeDictionary = new BadgeRepository();
        public void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Hello Security Admin, What would you like to do? \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit\n" +
                    "Enter the number of the option you would like to select");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
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
        public void CreateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number?");
            int badgeID = int.Parse(Console.ReadLine());
            List<string> accessibleDoors = new List<string>();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("List a door that it needs access to:");
                string door = Console.ReadLine();
                accessibleDoors.Add(door);
                Console.WriteLine("Any other doors? y/n:");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "y":
                        break;
                    case "n":
                        isRunning = false;
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }
            Badge newBadge = new Badge(badgeID, accessibleDoors);
            _badgeDictionary.AddBadge(newBadge);
            ReduceRed();
        }
        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int badgeNum = int.Parse(Console.ReadLine());
            Dictionary<int, List<string>> _badgeRepo = _badgeDictionary.GetBadges();
            List<string> updatedAccess = _badgeRepo[badgeNum];
            string stringUpdatedAccess = string.Join(", ", updatedAccess);
            Console.WriteLine($"{badgeNum} has access to {stringUpdatedAccess}");
            Console.WriteLine("What would you like to do? \n" + "1. Remove a door\n" + "2. Add a door");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string door = Console.ReadLine();
                    updatedAccess.Remove(door);
                    break;
                case "2":
                    Console.WriteLine("Waht door would you like to add?");
                    string newDoor = Console.ReadLine();
                    updatedAccess.Add(newDoor);
                    break;
                default:
                    break;
            }
            Badge updatedBadge = new Badge(badgeNum, updatedAccess);
            _badgeDictionary.UpdateBadge(updatedBadge);
            ReduceRed();
        }
        public void ListBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> displayDict = _badgeDictionary.GetBadges();
            Console.WriteLine("Badge #    Door Access");
            foreach(KeyValuePair<int, List<string>> badge in displayDict)
            {
                string stringDoors = string.Join(", ", badge.Value);
                Console.WriteLine($"{badge.Key}     {stringDoors}");
            }
            ReduceRed();
        }
        private void ReduceRed()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
