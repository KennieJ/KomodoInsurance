using KomodoInsurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        public void Run()
        {
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //display options
                Console.WriteLine("Select a task: \n" +
                    "1. Search the Developer Directory by ID number\n" +
                    "2. Search the Developer Directory by Name\n" +
                    "3. Check for missing Pluralsight licenses\n" +
                    "4. Add developers to the directory\n" +
                    "5. View complete developer directory\n" +       
                    "6. Add a Team\n" +
                    "7. View a Team\n" +
                    "8. Update a Team\n" +
                    "9. View Team Directory" +
                    "10. Remove a Team\n");


                //Get input
                //evaluate input and act
            }
        }

        //1. View by ID number
        private void DisplayDeveloperByID()
        {
            Console.WriteLine("Enter the developer's ID number:");
            string devID = Console.ReadLine();
            Developer person = _developerRepo.GetDeveloperByID(devID);

            if( person != null)
            {
                Console.WriteLine($"Full Name: {person.FirstName} {person.LastName}\n" +
                    $"DeveloperID: {person.DeveloperID}\n" +
                    $"Has Pluralsight Access: {person.PluralsightAccess}");
            }
            else
            {
                Console.WriteLine("Developer does not exist");
            }
        }

        //2. Search devs by name
            //enter a first or last name. return everyone that matches, one match, or null

        //3. check for pluralsight
            //view complete directory, only write to console if pluralsight = false
        private void DisplayFalsePluralsight()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDevelopers();
            Console.WriteLine("The following developers do not have access to Pluralsight:");
            foreach(Developer person in listOfDevelopers)
            {
                if(person.PluralsightAccess == false)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} ID: {person.DeveloperID}");
                }
            }
        }

        //4. add developer to directory (just single dev now, consider a while loop)
        private void CreateNewDeveloper()
        {
            Developer newDeveloper = new Developer();

            //First Name
            Console.WriteLine("Enter developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("Enter developer's last name:");
            newDeveloper.LastName = Console.ReadLine();

            //DevID
            Console.WriteLine("Enter developer's unique ID number:");
            newDeveloper.DeveloperID = Console.ReadLine();

            //Has Pluralsight access
            Console.WriteLine("Does the developer have access to Pluralsight? Enter Y/N");
            string pluralsightAnswer = Console.ReadLine().ToLower();

            if(pluralsightAnswer == "y")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
            }
        }
    
        //5. view full developer directory
        private void DisplayAllDevelopers()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDevelopers();
            foreach(Developer person in listOfDevelopers)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} ID: {person.DeveloperID}");
            }

        }

        //6. Add a team
        private void CreateNewTeam()
        {
            DevTeam newTeam = new DevTeam();

            //team name, team ID
            Console.WriteLine("Enter a team name:");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter a team ID:");
            newTeam.TeamID = Console.ReadLine();

            //add team members to list
            List<Developer> teamList = new List<Developer>();

        }

        //7. view a team


        //8. Update a team


        //9. view all teams


        //10. Remove a team


        //seed methods
        private void SeedDeveloperList()
        {

        }

        private void SeedDevTeamList()
        {

        }

    }
}
