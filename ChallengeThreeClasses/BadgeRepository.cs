using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClasses
{
    public class BadgeRepository
    {
        protected readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public bool AddBadge(Badge badge)
        {
            int count = _badgeDictionary.Count();
            _badgeDictionary.Add(badge.BadgeID, badge.AccessibleDoors);
            bool addResult = (_badgeDictionary.Count() > count) ? true : false;
            return addResult;
        }
        public bool UpdateBadge(Badge badge)
        {
            if (_badgeDictionary[badge.BadgeID] != null)
            {
                _badgeDictionary[badge.BadgeID] = badge.AccessibleDoors;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgeDictionary;
        }
    }
}
