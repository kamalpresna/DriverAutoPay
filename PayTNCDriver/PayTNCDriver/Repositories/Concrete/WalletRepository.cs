using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Repositories.Concrete
{
    public class WalletRepository
    {

        public IEnumerable<UserHPPProfile> FindByUserId(string userId)
        {
            return _context.UserHPPProfiles.Where(hpp => hpp.UserId == userId);
        }

        public UserHPPProfile FindByUserIdAndHPPProfileId(string userId, string hppProfileId)
        {
            return _context.UserHPPProfiles.FirstOrDefault(hpp => hpp.UserId == userId && hpp.HPPProfileId == hppProfileId);
        }


        public UserHPPProfile FindByHPPProfileId(string hppProfileId)
        {
            return _context.UserHPPProfiles.FirstOrDefault(hpp => hpp.HPPProfileId == hppProfileId);
        }

    }
}
