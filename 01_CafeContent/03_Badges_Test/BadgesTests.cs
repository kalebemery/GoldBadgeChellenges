using System;
using _03_Badges_repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Test
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void NewBadge_ShouldReturnTrue()
        {
            Badges test = new Badges();
            BadgesRepo repo = new BadgesRepo();


            bool wasAdded = repo.NewBadge(test);

            Assert.IsTrue(wasAdded);
        }



        [TestMethod]
        public void AccessDoor_ShouldReturnTrue()
        {

            Badges test = new Badges();
            BadgesRepo repo = new BadgesRepo();


            bool wasAdded = repo.AccessDoor(test);


            Assert.IsTrue(wasAdded);
        }
    }
}

