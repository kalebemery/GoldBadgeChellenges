using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_repo
{
    public class BadgesRepo
    {
        protected readonly Dictionary<int, List<string>> _dictionaryOfBadges = new Dictionary<int, List<string>>();

        //create
        public bool NewBadge(Badges newBadge)
        {
            int startingcount = _dictionaryOfBadges.Count();
           _dictionaryOfBadges.Add(newBadge.BadgeID, newBadge.doorAccess);
            bool wasAdded = (_dictionaryOfBadges.Count() > startingcount) ? true : false;
            return wasAdded;
            
        }


        public List<string> DoorByID(int id)
        {
            foreach (var key in _dictionaryOfBadges.Keys)
            {
                if (key == id)
                {
                    return _dictionaryOfBadges[id];
                }
            }
            return null;
        }
        public void GetDictionary()
        {
            foreach (KeyValuePair<int, List<string>> badgeInfo in _dictionaryOfBadges)
            {
                int badgeID = badgeInfo.Key;
                List<string> door = badgeInfo.Value;
                Console.WriteLine($"Badge ID: { badgeID }  Badge Info: {string.Join(",", door)}");
            }
        }


        public bool AccessDoor(Badges newBadge)
        {
            int startingcount = _dictionaryOfBadges.Count;
            int id = newBadge.BadgeID;
            List<string> listOfDoors = newBadge.doorAccess;
            _dictionaryOfBadges.Add(id, listOfDoors);
            bool wasAdded = (_dictionaryOfBadges.Count > startingcount) ? true : false;
            return wasAdded;
        }

        public bool DeleteAccess(int id, string doors)
        {
            int startingcount = _dictionaryOfBadges.Count;
            List<string> accessToDoors = DoorByID(id);
            accessToDoors.Remove(doors);
            _dictionaryOfBadges[id] = accessToDoors;
            bool wasDeleted = (_dictionaryOfBadges.Count < startingcount) ? true : false;
            return wasDeleted;
        }

    
        public string DisplayDoorAccess(int id)
        {
            
            foreach (KeyValuePair<int, List<string>> access in _dictionaryOfBadges)
            {
                if (access.Key == id)
                {
                    int badgeID = access.Key;
                    List<string> door = access.Value;
                    string accessToDoor = $"Badge ID:  {badgeID }  Door Access: {string.Join(",", door)}";
                    return accessToDoor;
                }
            }
            return null;
        }

        public void DoorAccess(int badgeID, string doorToAdd)
        {
            List<string> doors = DoorByID(badgeID);
            doors.Add(doorToAdd);
            _dictionaryOfBadges[badgeID] = doors;
        }

    }
}
