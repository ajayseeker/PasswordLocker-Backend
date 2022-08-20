using PasswordLockerLib.Infrasturcture;
using PasswordLockerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordLockerLibrary.Services
{
    public class AuthenticateService : IAuthenticate
    {
        public AuthenticateService()
        {
            _dataProvider = DataProviderFactory.GetAuthenticateDataProvider(Config.AuthenticationDB);
        }

        private IAuthenticateDataProvider _dataProvider = null;
        public bool IsUserNamePasswordValid(string userName, string password)
        {
            return _dataProvider.IsUserNameAndPasswordPresent(userName, password);
        }
        public bool RegisterUser(string userName, string password)
        {
            if (!_dataProvider.IsUserNamePresent(userName))
            {
                _dataProvider.AddUserInfo(userName, password);
                return true;
            }
            return false;
        }
    }
}
