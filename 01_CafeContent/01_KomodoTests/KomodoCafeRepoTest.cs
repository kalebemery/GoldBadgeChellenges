using System;
using System.Collections.Generic;
using _01_CafeContent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_KomodoTests
{
    [TestClass]
    public class KomodoCafeRepoTest
    {
        [TestMethod]
        public void AddToMenu_ShouldAddToList()
        {
            MenuContent content = new MenuContent();
            MenuContentRepo repo = new MenuContentRepo();

            //Act
            bool addResult = repo.AddContentToMenu(content);

            //Assert 
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetMenuContent_ShouldReturnCorrectCollection()
        {
            //Arrange
            MenuContent content = new MenuContent();
            MenuContentRepo repo = new MenuContentRepo();
            repo.AddContentToMenu(content);

            //Act
            List<MenuContent> contents = repo.GetMenuContentList();

            bool repoHasContent = contents.Contains(content);
            //Assert!
            Assert.IsTrue(repoHasContent);
        }

        private MenuContentRepo _repo;
        private MenuContent _content;
        //notice we are not writing new = because we are gong to do this in the test initialize
        [TestInitialize]

        public void Arrange()
        {
            _repo = new MenuContentRepo();
            _content = new MenuContent("Hibachi Steak", "Marinated steak with fried rice, sauteed vegetable," +
                "fried rice, and miso soup.", "steak, rice, brocolli, carrots, tofu", 18.99, 5);

            _repo.AddContentToMenu(_content);

        }

        [TestMethod]
        public void GetByMealName_ShouldReturnCorrectContent()
        {
            //act
            MenuContent searchResult = _repo.GetContentByMealName("Hibachi Steak");

            Assert.AreEqual(_repo, searchResult);
            //expect vs actual was not needed to be done in this example
            //bc we stated what we expected with _content = new
        }


        [TestMethod]
        public void RemoveMenuItem_ShouldReturnTrue()
        {
            // arrange
            MenuContent testcontent = _repo.GetContentByMealName("Hibachi Steak");

            //act
            bool removeResult = _repo.RemoveContentFromList("content");
            // assert
            Assert.IsTrue(removeResult);
        }
    }
}
    

