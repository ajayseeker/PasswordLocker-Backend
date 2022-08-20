using MongoDB.Driver;
using PasswordLockerLib.Infrasturcture;
using PasswordLockerLib.Interfaces;
using PasswordLockerLibrary;
using PasswordLockerLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLib.PersistanceServices
{
    public class AuthenticationDataTransferServiceMongoDb : IAuthenticateDataProvider
    {
        public AuthenticationDataTransferServiceMongoDb()
        {
            _userInfo = CollectionFactory.GetCollection<UserEntity>(Utilities.Collections.UserInfo);
            _credentialsInfo = CollectionFactory.GetCollection<CredentialEntity>(Utilities.Collections.Credentials);
        }
        private IMongoCollection<UserEntity> _userInfo;
        private IMongoCollection<CredentialEntity> _credentialsInfo;

        #region IAuthenticateDataTransfer Implementation
        public bool IsUserNamePresent(string userName)
        {
            try
            {
                var it = _userInfo.Find(obj => obj.UserName == userName);
                return it.Any();
            }
            catch(Exception ex)
            {
                Logger.Log(Utilities.LogCategory.Exception, "IsUserNamePresent() :  " + ex.Message);
                return false;
            }
            
        }
        public bool AddUserInfo(string userName, string password)
        {
            try
            {
                _userInfo.InsertOne(new UserEntity(userName, password));
            }
            catch(Exception ex)
            {
                Logger.Log(Utilities.LogCategory.Exception, "AddUserInfo() :  " + ex.Message);
                return false;
            }
            return true;
        }
        public bool IsUserNameAndPasswordPresent(string userName, string password)
        {
            try
            {
                var info = _userInfo.Find(obj => obj.UserName == userName && obj.Password == password);
                return info.Any();
            }
            catch(Exception ex)
            {
                Logger.Log(Utilities.LogCategory.Exception, "IsUserNameAndPasswordPresent() :  " + ex.Message);
                return false;
            }
        }
        #endregion
    }
}
