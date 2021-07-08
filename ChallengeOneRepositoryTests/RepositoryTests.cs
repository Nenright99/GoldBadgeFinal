using ChallengeOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneRepositoryTests
{
    [TestClass]
    public class MenuItemRepositoryTests
    {
        [TestMethod]
        public void AddItem_ShouldReturnCorrectBoolean()
        {
            Items newItem = new Items();
            ItemRepository repository = new ItemRepository();
            bool addResult = repository.AddItem(newItem);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectDirectory()
        {
            List<string> cubanIngredients = new List<string>() { "Turkey", "Pickles", "etc." };
            Items testItem = new Items(5, "The Cuban", "Cuban Sandwhich", cubanIngredients, 11.99m);
            ItemRepository repo = new ItemRepository();
            repo.AddItem(testItem);
            List<Items> contents = repo.GetDirectory();
            bool directoryHasItem = contents.Contains(testItem);
            Assert.IsTrue(directoryHasItem);
        }
        private Items _content;
        private ItemRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ItemRepository();
            List<string> cubanIngredients = new List<string>() { "Turkey", "Pickles", "etc." };
            _content = new Items(5, "The Cuban", "Cuban Sandwhich", cubanIngredients, 11.99m);
            _repo.AddItem(_content);
        }

        [TestMethod]
        public void GetByNumber_ShouldReturnCorrectItem()
        {
            //Arrange
            //Act
            Items searchResult = _repo.GetByNumber(5);
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void RemoveItem_ShouldReturnTrue()
        {
            //Arrange
            Items foundContent = _repo.GetByNumber(5);
            //Act
            bool removeResult = _repo.RemoveItem(foundContent);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
