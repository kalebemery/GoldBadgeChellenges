using _03_Badges_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    class ProgramUI
    {

        private readonly BadgesRepo _badgeRepo = new BadgesRepo();

        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, what would you like to do?: \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit program");
                string input = Console.ReadLine();
             
                switch (input)
                {
                    case "1":
                        {
                            AddABadge();
                            break;
                        }
                    case "2":
                        {
                            UpdateABadge();
                            break;
                        }
                    case "3":
                        {
                            ListAllBadges();
                            break;
                        }
                    case "4":
                        {
                            keeprunning = false;
                            break;
                        }
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
        }

        private void AddABadge()
        {
            Console.Clear();
            Badges AddABadge = new Badges();

            Console.WriteLine("What is the number on the badge:");
            string badgeIdAsSring = Console.ReadLine();
            AddABadge.BadgeID = int.Parse(badgeIdAsSring);


            bool needsMoreDoorsAccessed = true;
            List<string> accessibleDoors = new List<string>();
            do
            {
                Console.WriteLine("List a door that it needs access to: ");
                string whatDoorNeedsAccess = Console.ReadLine();
                accessibleDoors.Add(whatDoorNeedsAccess);

                Console.WriteLine("Any other doors(y/n)?");
                string userInput = Console.ReadLine();


                if (userInput.ToLower() == "y")
                {
                    needsMoreDoorsAccessed = true;
                }
                else
                {
                    AddABadge.doorAccess = accessibleDoors;
                    needsMoreDoorsAccessed = false;
                }

            } 
            while (needsMoreDoorsAccessed);
            

            _badgeRepo.NewBadge(AddABadge);
            Console.WriteLine("Please press any key to coninute.");
            Console.ReadLine();
        }

        private void UpdateABadge()
        {
            Console.WriteLine("What is the badge number to update?");
            string badgeAsString = Console.ReadLine();
            int badgeID = int.Parse(badgeAsString);

            List<string> whatAccessDoorIDHas = _badgeRepo.DoorByID(badgeID);
            Console.WriteLine(_badgeRepo.DisplayDoorAccess(badgeID));
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        Console.WriteLine("Which door would you like to remove?");
                        string removeDoor = Console.ReadLine();
                        _badgeRepo.DeleteAccess(badgeID, removeDoor);
                        Console.WriteLine(_badgeRepo.DisplayDoorAccess(badgeID));
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Which door would you like to add?");
                        string addDoor = Console.ReadLine();
                        _badgeRepo.DoorAccess(badgeID, addDoor);
                        Console.WriteLine(_badgeRepo.DisplayDoorAccess(badgeID));
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter a valid response.");
                        Console.ReadKey();
                        break;
                    }
            }

        }

        private void ListAllBadges()
        {
            _badgeRepo.GetDictionary();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        private void SeedContentList()
        {

            List<string> seedContentOne = new List<string>();
            Badges badgeOne = new Badges();
            seedContentOne.Add("A7");
            badgeOne.BadgeID = 12345;
            badgeOne.doorAccess = seedContentOne;
            _badgeRepo.NewBadge(badgeOne);

            List<string> seedContentTwo = new List<string>();
            Badges badgeTwo = new Badges();
            seedContentTwo.Add("A1");
            seedContentTwo.Add("A4");
            seedContentTwo.Add("B1");
            seedContentTwo.Add("B2");
            badgeTwo.BadgeID = 22345;
            badgeTwo.doorAccess = seedContentTwo;
            _badgeRepo.NewBadge(badgeTwo);

            List<string> seedContentThree = new List<string>();
            Badges badgeThree = new Badges();
            seedContentThree.Add("A4");
            seedContentThree.Add("A5");         
            badgeThree.BadgeID = 32345;
            badgeThree.doorAccess = seedContentThree;
            _badgeRepo.NewBadge(badgeThree);

      
        }

    }

}
