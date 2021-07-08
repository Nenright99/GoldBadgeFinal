using ChallengeTwoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoInterface
{
    class ProgramUI
    {
        public void Run()
        {
            DisplayMenu();
        }
        protected readonly ClaimRepository _claimDirectory = new ClaimRepository();
        public void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Choose a menu item: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit\n" +
                    "Enter the number of the option you would like to select");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        AddressNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
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
        public void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Claim ID     Type        Description     Amount      DateOfAccident      DateOfClaim     IsValid");
            foreach(Claim claim in _claimDirectory.GetClaims())
            {
                Console.WriteLine($"{claim.ClaimID}         {claim.ClaimType}    {claim.Description}    {claim.ClaimAmount}     {claim.DateOfIncident}     {claim.DateOfClaim}      {claim.IsValid}");
            }
            ReduceRed();
        }
        public void AddressNextClaim()
        {
            Queue<Claim> currentQueue = _claimDirectory.GetClaims();
            Claim nextClaim = currentQueue.Peek();
            Console.WriteLine
                (
                "Here are the details for the next claim to handle: \n" +
                $"ClaimID: {nextClaim.ClaimID} \n" +
                $"Type: {nextClaim.ClaimType} \n" +
                $"Description: {nextClaim.Description} \n" +
                $"Amount: {nextClaim.ClaimAmount} \n" +
                $"DateOfAccident: {nextClaim.DateOfIncident} \n" +
                $"DateOfClaim: {nextClaim.DateOfClaim} \n" +
                $"IsValid: {nextClaim.IsValid} \n" +
                "Do you want to deal with this claim now? y/n:"
                );
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    _claimDirectory.RemoveNextClaim();
                    break;
                case "n":
                    break;
                default:
                    break;
            }
        }
        public void AddNewClaim()
        {
            Console.WriteLine("Enter the claim ID: ");
            int claimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of the claim type:\n" + "1. Car\n" + "2. Home\n" + "3. Theft");
            string stringClaimType = Console.ReadLine();
            TypeOfClaim claimType;
            claimType = (TypeOfClaim)int.Parse(stringClaimType);
            Console.Clear();
            Console.WriteLine("Enter a claim description:");
            string description = Console.ReadLine();
            Console.WriteLine("Amount of Damage:");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Year of the incident (XXXX):");
            int y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Month of the incident:");
            int m1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Day of the incident:");
            int d1 = int.Parse(Console.ReadLine());
            DateTime dateOfIncident = new DateTime(y1, m1, d1);
            Console.Clear();
            Console.WriteLine("Year of the claim (XXXX):");
            int y2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Month of the claim:");
            int m2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Day of the claim:");
            int d2 = int.Parse(Console.ReadLine());
            DateTime dateOfClaim = new DateTime(y2, m2, d2);
            Claim claim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            _claimDirectory.AddClaim(claim);
            Console.Clear();
            if (claim.IsValid)
            {
                Console.WriteLine("This claim is valid");
                ReduceRed();
            }
            else
            {
                Console.WriteLine("This claim is not valid");
                ReduceRed();
            }

        }
        private void ReduceRed()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
