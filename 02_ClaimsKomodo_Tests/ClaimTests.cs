using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using _02_ClaimsKomodo_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsKomodo_Tests
{
    [TestClass]
    public class ClaimTests
    {

        [TestMethod]
        public void AddClaimToQueue_ShouldAddToQueue()
        {
            ClaimsContent content = new ClaimsContent();
            ClaimsContentRepo repo = new ClaimsContentRepo();

            bool wasAdded = repo.AddClaimToQueue(content);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void ClaimDequeue_ShouldDequeue()
        {
            ClaimsContent content = new ClaimsContent();
            ClaimsContentRepo repo = new ClaimsContentRepo();

            bool wasDequeued = repo.ClaimDequeue(content);

            Assert.IsTrue(wasDequeued);
        }

        [TestMethod]
        public void GetContentByQueue_ShouldBeCorrectTrue()
        {
            ClaimsContent content = new ClaimsContent();
            ClaimsContentRepo repo = new ClaimsContentRepo();
            repo.AddClaimToQueue(content);

            Queue<ClaimsContent> testQueue = repo.GetContentFromQueue();
            bool queueHasContent = testQueue.Contains(content);

            Assert.IsTrue(queueHasContent);

        }

        private ClaimsContentRepo _repo;
        private ClaimsContent _content;
        
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsContentRepo();
            _content = new ClaimsContent(1, ClaimsType.Car, "Car accident on 465.", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Queue<ClaimsContent> _claimsrepo = new Queue<ClaimsContent>();
            _claimsrepo.Enqueue(_content);
        }
        

        [TestMethod]
        public void NextClaim_ShouldBeCorrect()
        {
            _repo = new ClaimsContentRepo();
            Queue<ClaimsContent> _queueofclaims = new Queue<ClaimsContent>();
            _content = new ClaimsContent();
            _content.ClaimsID = 1;
            _repo.AddClaimToQueue(_content);

            int test = 1;
            ClaimsContent claim = _repo.NextClaim();
            int actual = claim.ClaimsID;

            Assert.AreEqual(actual, test);


        }
    }
}
