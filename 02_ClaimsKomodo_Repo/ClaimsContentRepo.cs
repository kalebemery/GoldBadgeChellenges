using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsKomodo_Repo
{
    public class ClaimsContentRepo
    {
        protected readonly Queue<ClaimsContent> _queueOfClaimsRepo = new Queue<ClaimsContent>();

        //create
        public bool AddClaimToQueue(ClaimsContent content)
        {
            int startingCount = _queueOfClaimsRepo.Count;
            _queueOfClaimsRepo.Enqueue(content);
            bool wasAdded = (_queueOfClaimsRepo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //read
        public Queue<ClaimsContent> GetContentFromQueue()
        {
            return _queueOfClaimsRepo;
        }

            

        public ClaimsContent NextClaim()
        {
            ClaimsContent claim = _queueOfClaimsRepo.Peek();
            Console.WriteLine($"Claims ID{claim.ClaimsID} \n" +
                   $"Description:{claim.Description}\n" +
                   $"Amount:{claim.ClaimAmount}\n" +
                   $"Date of accident:{claim.DateOfClaim}\n" +
                   $"Date of claim: {claim.DateOfClaim}\n");
            if (claim.IsValid)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invallid");
            }
            return claim;
        }

        public bool ClaimDequeue()
        {
            int startingCount = _queueOfClaimsRepo.Count;
            _queueOfClaimsRepo.Dequeue();
            bool wasDequeued = (_queueOfClaimsRepo.Count < startingCount) ? true : false;

            return wasDequeued;
        }

        public bool ClaimDequeue(ClaimsContent content)
        {
            int startingCount = _queueOfClaimsRepo.Count;
            _queueOfClaimsRepo.Dequeue();
            bool wasDequeued = (_queueOfClaimsRepo.Count < startingCount) ? true : false;

            return wasDequeued;
        }
        //Enter a new claim(like add content to list)
    }
}
//see all claims(aka like get contents)
//how do i get the queue to display like rows and columns??
//seed content for the 3 claims

//take care of next claim (like get content by title, except claim ID? Or-->
//use .peak method to preview  next in queue
//use bool. if y(true) then dequeue next in queue, if no return to main menu(exit)
//if yes, then have it console writeline to user all of the contents for that claim(use dequeue)
//Enter a new claim(like add content to list)