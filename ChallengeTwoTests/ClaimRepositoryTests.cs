using ChallengeTwoClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoTests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void AddClaim_ShouldReturnTrue()
        {
            Claim newClaim = new Claim();
            ClaimRepository repository = new ClaimRepository();
            bool addResult = repository.AddClaim(newClaim);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetClaims_ShouldReturnCorrectDirectory()
        {
            DateTime testD1 = new DateTime(2021, 03, 20);
            DateTime testD2 = new DateTime(2021, 04, 25);
            Claim testClaim = new Claim(1, TypeOfClaim.Car, "fender bender", 315.99m, testD1, testD2);
            ClaimRepository repo = new ClaimRepository();
            repo.AddClaim(testClaim);
            Queue<Claim> Claims = repo.GetClaims();
            bool directoryHasClaim = Claims.Contains(testClaim);
            Assert.IsTrue(directoryHasClaim);
        }
        private Claim _claim;
        private ClaimRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            DateTime testD1 = new DateTime(2021, 03, 20);
            DateTime testD2 = new DateTime(2021, 04, 25);
            _claim = new Claim(1, TypeOfClaim.Car, "fender bender", 315.99m, testD1, testD2);
            _repo.AddClaim(_claim);
        }
        [TestMethod]
        public void RemoveNextClaim_ShouldReturnTrue()
        {
            bool removeResult = _repo.RemoveNextClaim();
            Assert.IsTrue(removeResult);
        }
    }
}
