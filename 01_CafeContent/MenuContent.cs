using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeContent

{
 

    public class MenuContent
    {
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public int MealNumber { get; set; }
        public MenuContent() { }

        public MenuContent(string mealname, string description, string ingredients, double price, int mealnumber)
        {
            MealName = mealname;
            Description = description;
            Ingredients = ingredients;
            Price = price;
            MealNumber = mealnumber;
            
        }
    }




   
}
