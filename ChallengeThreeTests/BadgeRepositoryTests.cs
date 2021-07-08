using ChallengeThreeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            Badge newBadge = new Badge();
            BadgeRepository repository = new BadgeRepository();
            bool addResult = repository.AddBadge(newBadge);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetBadges_ShouldReturnCorrectDictionary()
        {
            List<string> doors = new List<string>() { "A1", "A2", "B1" };
            Badge testBadge = new Badge(1, doors);
            BadgeRepository repo = new BadgeRepository();
            repo.AddBadge(testBadge);
            Dictionary<int, List<string>> contents = repo.GetBadges();
            bool directoryHasBadge = (contents[testBadge.BadgeID] == testBadge.AccessibleDoors) ? true : false;
            Assert.IsTrue(directoryHasBadge);
        }
        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            List<string> doors = new List<string>() { "A1", "A2", "B1" };
            Badge testBadge = new Badge(1, doors);
            BadgeRepository repo = new BadgeRepository();
            repo.AddBadge(testBadge);
            List<string> updatedDoors = new List<string>() { "A1", "A2", "A3", "A4" };
            Badge updatedBadge = new Badge(testBadge.BadgeID, updatedDoors);
            bool updateResult = repo.UpdateBadge(updatedBadge);
            Assert.IsTrue(updateResult);
        }
    }
}
