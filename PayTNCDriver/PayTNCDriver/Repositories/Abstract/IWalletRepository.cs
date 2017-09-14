using CARS.Data.DataAccess;
using PayTNCDriver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Repositories.Abstract
{
    public interface IWalletRepository
    {
        UserHPPProfileDTO FindByUserId(int userId);
        UserHPPProfile FindByUserIdAndHPPProfileId(string userId, string hppProfileId);
        UserHPPProfile FindByHPPProfileId(string hppProfileId);
        Model.PaymentType FindPaymentTypeById(int? paymentTypeId);
        bool HasHPPProfilesInDatabase(string userId);
        bool HPPProfileIdExistsInDatabase(string hppProfileId);
        void ProcessAchTransactions(IList<DriverInfo> achTransactionList);
    }
}
