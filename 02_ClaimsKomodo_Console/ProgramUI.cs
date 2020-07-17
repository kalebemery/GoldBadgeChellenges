using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _02_ClaimsKomodo_Repo;


namespace _02_ClaimsKomodo_Console
{
    class ProgramUI
    {
        private ClaimsContentRepo _claimsRepo = new ClaimsContentRepo();
        public void Run()
        {
            SeedContentList();
            StartingPage();
        }

        private void StartingPage()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display
                Console.WriteLine("Select a menu option:\n" +
                    "1. See all claims: \n" +
                    "2. Take care of next claim:\n" +
                    "3. Enter A new claim\n" +
                    "4. Exit");

                //Get User Input
                string input = Console.ReadLine();

                //Evaluate input and act
                switch (input)
                {
                    case "1":
                        printQueue();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Have a great day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }


        private void printQueue()
        {
            Console.Clear();

            Queue<ClaimsContent> getclaims = _claimsRepo.GetContentFromQueue();
            foreach (ClaimsContent claim in getclaims)
            {
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
              
            }
            Console.WriteLine("Press any key to continue");
        }

        private void TakeCareOfClaim()
        {
            ClaimsContent upNext = _claimsRepo.NextClaim();
            
            Console.WriteLine("Do you want to deal with this claim now?(y/n)");
            string userinput = Console.ReadLine();

            if(userinput.ToLower() == "y")
            {
                _claimsRepo.ClaimDequeue();
            }
            if(userinput.ToLower() == "n")
            {
                
            }
                    
        }

        private void NewClaim()
        {
            Console.Clear();
            ClaimsContent enterClaim = new ClaimsContent();

            Console.WriteLine("Enter the claim ID:");
            string claimIdAsString = Console.ReadLine();
            enterClaim.ClaimsID = int.Parse(claimIdAsString);

            Console.WriteLine("Enter the claim type(1, 2, or 3):");
            string claimInput = Console.ReadLine();
            int claimID = int.Parse(claimInput);
            enterClaim.TypeOfClaim = (ClaimsType)claimID;
           

            Console.WriteLine("Enter a claim description:");
            enterClaim.Description = Console.ReadLine();

            Console.WriteLine("Amount of damage(no $ necessary)");
            string amountAsString = Console.ReadLine();
            enterClaim.ClaimAmount = decimal.Parse(amountAsString);

            Console.WriteLine("Date of Accident(YYYY,MM,DD):");
            enterClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Date of Claim(YYYY,MM,DD:");
            enterClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());



            _claimsRepo.AddClaimToQueue(enterClaim);
        }


        private void SeedContentList()
        {
            _claimsRepo.AddClaimToQueue(new ClaimsContent(1, ClaimsType.Car, "Car accident on 465.", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27)));
            _claimsRepo.AddClaimToQueue(new ClaimsContent(2, ClaimsType.Home, "House fire in kitchen", 4000, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12)));
            _claimsRepo.AddClaimToQueue(new ClaimsContent(3, ClaimsType.Theft, "Stolen pancakes.", 4, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01)));
        }

    }
}
