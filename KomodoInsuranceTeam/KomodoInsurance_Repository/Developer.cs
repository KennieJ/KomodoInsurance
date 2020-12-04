using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class Developer
    {
        //POCOs
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeveloperID { get; set; }         //Unique identifier
        public bool PluralsightAccess { get; set; }
        

        public Developer() { }

        public Developer(string firstName, string lastName, string developerID, bool pluralsightAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            DeveloperID = developerID;
            PluralsightAccess = pluralsightAccess;
        }
    }
}
