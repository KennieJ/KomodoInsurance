using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public string TeamID { get; set; }

        //need team members prop. list of developers. list is not a return type
        public List<Developer> TeamMembers { get; set; }
        
    }
}
