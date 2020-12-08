using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class DevTeamRepo
    {
        private List<DevTeam> _listOfDevTeams = new List<DevTeam>();
        private List<Developer> _listOfTeamMembers = new List<Developer>();

        //Create
        public void AddTeamToList(DevTeam team)
        {
            _listOfDevTeams.Add(team);
        }

        public void AddDeveloperToTeam(Developer person, string teamID)
        {
            DevTeam team = GetTeamByID(teamID);
            team.TeamMembers.Add(person);
        }

        //Read
        public List<DevTeam> GetDevTeams()
        {
            return _listOfDevTeams;
        }

        public List<Developer> GetTeamMemberList()
        {
            return _listOfTeamMembers;
        }

        //Update
        public bool UpdateExistingTeam(string originalID, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamByID(originalID);

            if(oldTeam != null)
            {
                oldTeam.TeamID = newTeam.TeamID;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamMembers = newTeam.TeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveTeamFromList(string teamID)
        {
            DevTeam team = GetTeamByID(teamID);

            if(team == null)
            {
                return false;
            }

            int initialCount = _listOfDevTeams.Count;
            _listOfDevTeams.Remove(team);

            if(initialCount > _listOfDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDevFromTeam(Developer person, string teamID)
        {
            DevTeam team = GetTeamByID(teamID);
            if(team == null)
            {
                return false;
            }

            if (_listOfTeamMembers.Contains(person))
            {
                int initialCount = _listOfTeamMembers.Count;
                _listOfTeamMembers.Remove(person);

                if (initialCount > _listOfTeamMembers.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //helper
        public DevTeam GetTeamByID(string teamID)
        {
            foreach (DevTeam team in _listOfDevTeams)
            {
                if(team.TeamID == teamID)
                {
                    return team;
                }
            }

            return null;
        }
    }
}
