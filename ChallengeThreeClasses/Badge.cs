using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClasses
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeID, List<string> accessibleDoors)
        {
            BadgeID = badgeID;
            AccessibleDoors = accessibleDoors;
        }
        public int BadgeID { get; set; }
        public List<string> AccessibleDoors { get; set; }
    }
}
