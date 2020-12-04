using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class DeveloperRepo
    {
        private List<Developer> _listOfDevelopers = new List<Developer>();

        //Create
        public void AddDeveloperToList(Developer person)
        {
            _listOfDevelopers.Add(person);
        }

        //Read
        public List<Developer> GetDevelopers()
        {
            return _listOfDevelopers;
        }

        //Update (is this necessary?)
        public bool UpdateExistingDeveloper(string originalID, Developer newPerson)
        {
            //find the developer by devID (is unique)
            Developer oldPerson = GetDeveloperByID(originalID);

            //update the developer info
            if(oldPerson != null)
            {
                oldPerson.FirstName = newPerson.FirstName;
                oldPerson.LastName = newPerson.LastName;
                oldPerson.DeveloperID = newPerson.DeveloperID;
                oldPerson.PluralsightAccess = newPerson.PluralsightAccess;
                return true;
            }
            else
            {
                return false;       //not sure if this is whats needed for Komodo
            }
        }

        //Delete
        public bool RemoveDeveloperFromList(string devID)
        {
            Developer person = GetDeveloperByID(devID);

            if(person == null)                              //if developer doesn't exist on list, can't delete
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(person);

            if(initialCount > _listOfDevelopers.Count)      //confirm developer was deleted from list
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method(s)
        public Developer GetDeveloperByID(string devID)
        {
            foreach (Developer person in _listOfDevelopers)
            {
                if(person.DeveloperID == devID)
                {
                    return person;
                }
            }

            return null;
        }
    }
}
