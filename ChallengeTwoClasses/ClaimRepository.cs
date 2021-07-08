using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClasses
{
    public class ClaimRepository
    {
        protected readonly Queue<Claim> _claimDirectory = new Queue<Claim>();
        public bool AddClaim(Claim newClaim)
        {
            int count = _claimDirectory.Count();
            _claimDirectory.Enqueue(newClaim);
            bool addResult = (_claimDirectory.Count() > count) ? true : false;
            return addResult;
        }
        public Queue<Claim> GetClaims()
        {
            return _claimDirectory;
        }
        public bool RemoveNextClaim()
        {
            int count = _claimDirectory.Count();
            if (count > 0)
            {
                _claimDirectory.Dequeue();
                bool removeResult = (_claimDirectory.Count() < count) ? true : false;
                return removeResult;
            }
            else
            {
                return false;
            }
        }
    }
}
