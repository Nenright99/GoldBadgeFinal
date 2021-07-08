using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClasses
{
    public enum TypeOfClaim
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claim
    {
        public Claim() { }
        public Claim(int claimID, TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan difference = DateOfClaim - DateOfIncident;
                if (difference.TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
