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
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
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
                    "2. Check for missing Pluralsight licenses\n" +
                    "3. Add developers to the directory\n" +
                    "4. View complete developer directory\n" +       
                    "5. Add a Team\n" +
                    "6. Add developers to a Team\n" +
                    "7. Find a Team\n" +
                    "8. Remove developers from a Team\n" +
                    "9. View Team Directory\n" +
                    "10. Remove a Team\n" +
                    "11. Exit Menu");


                //Get input
                string input = Console.ReadLine();

                //evaluate input and act
                switch (input)
                {
                    case "1":
                        DisplayDeveloperByID();
                        break;
                    case "2":
                        DisplayFalsePluralsight();
                        break;
                    case "3":
                        CreateNewDeveloper();
                        break;
                    case "4":
                        DisplayAllDevelopers();
                        break;
                    case "5":
                        CreateNewTeam();
                        break;
                    case "6":
                        AddDevelopersToTeam();
                        break;
                    case "7":
                        ViewTeamByID();
                        break;
                    case "8":
                        RemoveDevFromTeam();
                        break;
                    case "9":
                        DisplayAllTeams();
                        break;
                    case "10":
                        DeleteATeam();
                        break;
                    case "11":
                        break;
                    case "12":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu number");
                        break;
                }
            }
        }

        //1. View developer by ID number
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

        //2. check for pluralsight
            
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

        //3. add developer to directory (just single dev now, consider a while loop)
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

            //add developer to list
            List<Developer> developers = _developerRepo.GetDevelopers();
            developers.Add(newDeveloper);

        }
    
        //4. view full developer directory
        private void DisplayAllDevelopers()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDevelopers();
            foreach(Developer person in listOfDevelopers)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} ID: {person.DeveloperID}");
            }

        }

        //5. Add a team
        private void CreateNewTeam()
        {
            DevTeam newTeam = new DevTeam();

            //team name, team ID
            Console.WriteLine("Enter a team name:");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter a team ID:");
            newTeam.TeamID = Console.ReadLine();

            List<DevTeam> teams = _devTeamRepo.GetDevTeams();
            teams.Add(newTeam);
        }

        //6. add developers to a team (one at a time)
        private void AddDevelopersToTeam()
        {
            DisplayAllDevelopers();
            Console.WriteLine("Which developer would you like to add to a team? Enter an ID.");
            string input = Console.ReadLine();

            Developer newDev = _developerRepo.GetDeveloperByID(input);

            //view list of teams
            Console.WriteLine("What team would you like to add them to?");
            string teamID = Console.ReadLine();
            _devTeamRepo.AddDeveloperToTeam(newDev, teamID);
            
        }

        //7. view a team by ID
        private void ViewTeamByID()
        {
            Console.WriteLine("Enter a DevTeam ID");
            string teamID = Console.ReadLine();

            DevTeam team = _devTeamRepo.GetTeamByID(teamID);

            if(team != null)
            {
                Console.WriteLine($"Team Name: {team.TeamName}\n" +
                    $"Team ID: {team.TeamID}\n" +
                    $"Team Members: {team.TeamMembers}");
            }
            else
            {
                Console.WriteLine("Team does not exist");
            }
        }

        //8. Remove dev from a team
        private void RemoveDevFromTeam()
        {
            DisplayAllTeams();
            Console.WriteLine("Enter a team ID:");
            string teamID = Console.ReadLine();

            Console.WriteLine("Enter a developer ID to remove:");
            string personString = Console.ReadLine();
            Developer person = _developerRepo.GetDeveloperByID(personString);

            bool wasDeleted = _devTeamRepo.RemoveDevFromTeam(person, teamID);
            if (wasDeleted)
            {
                Console.WriteLine("Developer successfully removed from team");
            }
            else
            {
                Console.WriteLine("Could not remove developer from team");
            }


        }

        //9. view all teams
        private void DisplayAllTeams()
        {
            List<DevTeam> listOfTeams = _devTeamRepo.GetDevTeams();
            foreach(DevTeam team in listOfTeams)
            {
                Console.WriteLine($"{team.TeamName} ID: {team.TeamID}\n" +
                    $"{team.TeamMembers}");
            }
        }

        //10. Remove a team
        private void DeleteATeam()
        {
            DisplayAllTeams();
            Console.WriteLine("\nEnter the ID of the team you wish to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepo.RemoveTeamFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully removed.");
            }
            else
            {
                Console.WriteLine("The team could not be deleted");
            }
        }

        //11.remove a developer
        private void DeleteADeveloper()
        {
            DisplayAllDevelopers();
            Console.WriteLine("\nEnter the developer ID you wish to remove:");

            string input = Console.ReadLine();
            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("Successfully removed.");
            }
            else
            {
                Console.WriteLine("Could not remove developer");
            }
        }

        //seed methods
        private void SeedDeveloperList()
        {
            Developer person1 = new Developer("Kendra", "Joseph", "12345", true);
            Developer person2 = new Developer("Devvy", "McGoo", "23456", false);
        }

        private void SeedDevTeamList()
        {

        }

    }
}
