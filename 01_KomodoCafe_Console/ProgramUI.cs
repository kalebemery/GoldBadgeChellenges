using _01_CafeContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_KomodoCafe_Console
{
    class ProgramUI
    {
        //we make this repo a field so when our loop goes through and adds something, the menucontent will still be saved
        private MenuContentRepo _menuRepo = new MenuContentRepo();
        public void Run()
        {
            SeedContentList();
            StartingPage();
        }

        //Menu
        private void StartingPage()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create new Menu Content:\n" +
                    "2. View all items\n" +
                    "3. Delete existing menu content\n" +
                    "4. Exit");

                //Get User Input
                
                string input = Console.ReadLine();

                //Evaluate input and act
                switch (input)
                {
                    case "1":
                        CreateNewMenuContent();
                        break;
                    case "2":
                        DisplayAllContent();
                        break;
                    case "3":
                        DeleteExistingMenuContent();
                        break;
                    case "4":
                        Console.WriteLine("Have a great day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.ReadKey();
                
            }
        }

        private void CreateNewMenuContent()
        {
            Console.Clear();
            MenuContent newContent = new MenuContent();

            Console.WriteLine("Enter the name of the menu item:");
            newContent.MealName = Console.ReadLine();

            Console.WriteLine("Please enter the description for the menu item:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the menu item:");
            string ingredientsAsString = Console.ReadLine();
            newContent.Ingredients = ingredientsAsString;

            Console.WriteLine("Please enter the price of the menu item");
            string priceAsString = Console.ReadLine();
            newContent.Price = double.Parse(priceAsString);

            Console.WriteLine("Please enter the meal # of menu item.");
            string menuNumAsString = Console.ReadLine();
            newContent.MealNumber = int.Parse(menuNumAsString);
            Console.WriteLine("");

            _menuRepo.AddContentToMenu(newContent);
            Console.WriteLine("Press any key to continue");
           
        }

        private void DisplayAllContent()
        {

            List<MenuContent> listofmenucontent = _menuRepo.GetMenuContentList();

            foreach(MenuContent content in listofmenucontent)
            {
                Console.WriteLine($"Meal Name: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"Price: {content.Price}\n" +
                    $"Meal Number: {content.MealNumber}");
                Console.WriteLine("");
            }
            
        }

        private void DeleteExistingMenuContent()
        {
            DisplayAllContent();
            Console.WriteLine("Which menu item would you like to remove?");

            string input = Console.ReadLine();

            _menuRepo.RemoveContentFromList(input);

         
            Console.WriteLine("Please press any key to return To menu");
        }

        //seed method
        private void SeedContentList()
        {
            MenuContent HibachiSteak = new MenuContent("Hibachi Steak", "Marinated steak with fried rice, sauteed vegetable," +
                "fried rice, and miso soup.", "steak, rice, broccoli, carrots, onion, chicken broth, tofu" , 18.99, 5);

            _menuRepo.AddContentToMenu(HibachiSteak);

            MenuContent HibachiChicken = new MenuContent("Hibachi Chicken", "Marinated chicken with fried rice, sauteed vegetable," +
               "fried rice, and miso soup.", "steak, rice, broccoli, carrots, onion, chicken broth, tofu", 18.99, 5);

            _menuRepo.AddContentToMenu(HibachiChicken);
        }


    }
}
