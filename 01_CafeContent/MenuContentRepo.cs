using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeContent
{
    public class MenuContentRepo
    {
        protected readonly List<MenuContent> _listOfMenuConent = new List<MenuContent>();

        
        public bool AddContentToMenu(MenuContent content)
        {
            int startingCount = _listOfMenuConent.Count;
            _listOfMenuConent.Add(content);
            bool wasAdded = (_listOfMenuConent.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //read
        public List<MenuContent> GetMenuContentList()
        {

            return _listOfMenuConent;

        }

        //delete
        public bool RemoveContentFromList(string mealname)
        {
            MenuContent content = GetContentByMealName(mealname);

            if(content == null)
            {
                return false;
            }

            int startingCount = _listOfMenuConent.Count;
            _listOfMenuConent.Remove(content);

            if(startingCount < _listOfMenuConent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method for delete
        public MenuContent GetContentByMealName(string mealname)
        {
            foreach(MenuContent content in _listOfMenuConent)
            {
                if(content.MealName == mealname)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
