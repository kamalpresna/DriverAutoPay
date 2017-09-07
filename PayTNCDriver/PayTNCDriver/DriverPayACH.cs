using Paymentech;
using PayTNCDriver.Model;
using System.Collections.Generic;
using TotalTransit.ChaseLibrary;
using TotalTransit.ChaseLibrary.Concrete;
using TotalTransit.ChaseLibrary.Enums;

namespace PayTNCDriver
{
    public class DriverPayACH
    {
       

        public IEnumerable<UserHPPProfile> GetUserUserHPPProfiles(string driverNumber)
        {
            IEnumerable<UserHPPProfile> hppProfiles = _walletRepository.FindByUserId(driverNumber);
            return hppProfiles;
        }

        public UserHPPProfileBindingModel GetHPPProfile(string hppProfileId)
        {
            UserHPPProfileBindingModel hppProfileModel = new UserHPPProfileBindingModel();

            Transaction transaction = OrbitalTransactionFactory.CreateNewTransaction(ChaseHPPProfileActionsEnum.RETRIEVE);
            transaction[OrbitalConfigurationParameterNames.CUSTOMER_REF_NUM] = hppProfileId;

            OrbitalTransaction orbitalTransaction = new OrbitalTransaction();
            OrbitalResponse response = orbitalTransaction.ProcessProfile(transaction);

            if (response.Code == 0 && response.Message == OrbitalConfigurationParameterNames.SUCCESS_CUSTOMER_PROFILE_MESSAGE)
            {
                UserHPPProfile hppProfile = _walletRepository.FindByHPPProfileId(hppProfileId); //_mapper.Map<UserHPPProfileBindingModel, UserHPPProfile>(hppProfileModel);
                hppProfileModel = _mapper.Map<UserHPPProfile, UserHPPProfileBindingModel>(hppProfile);
                hppProfileModel.CustomerName = response.CustomerName;
                hppProfileModel.AccountNumber = response.AccountNumber;
                hppProfileModel.RoutingNumber = response.RoutingNumber;
                hppProfileModel.ECPAccountType = response.ECPAccountType;
                hppProfileModel.Status = response.Status;

                hppProfileModel.CustomerAddress1 = response.CustomerAddress1;
                hppProfileModel.CustomerAddress2 = response.CustomerAddress2;
                hppProfileModel.CustomerCity = response.CustomerCity;
                hppProfileModel.CustomerState = response.CustomerState;
                hppProfileModel.CustomerZip = response.CustomerZip;

            }

            return hppProfileModel;
        }

    }
}
