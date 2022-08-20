using PasswordLockerLib.Infrasturcture;
using PasswordLockerLib.Interfaces;
using PasswordLockerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordLockerLibrary.Services
{
    public class CredentialService : ICRUDCredentials
    {
        public CredentialService()
        {
            _dataProvider = DataProviderFactory.GetCredentialsDataProvider(Config.CredentialDB);
        }
        private ICredentialsDataTransfer _dataProvider = null;

        #region ICRUDCredentials
        public List<CredentialInfo> GetUserCredentials(string userHash)
        {
            var credentials = _dataProvider.GetCredentials(userHash);
            List<CredentialInfo> credentialsInfo = new List<CredentialInfo>();
            foreach(var credential in credentials)
            {
                credentialsInfo.Add(Utilities.ConvertCredentialEntityToCredentialInfo(credential));
            }
            return credentialsInfo;
        }
        public bool AddCredential(string userHash, string userName, string password, string website)
        {
            CredentialEntity entity = new CredentialEntity(website, userName, password, userHash);
            if (!_dataProvider.AreCredentialPresent(entity))
            {
                return _dataProvider.AddCredential(entity);
            }
            return false;
        }

        public bool RemoveCredential(string userHash, string userName, string password, string website)
        {
            return _dataProvider.RemoveCredential(new CredentialEntity(website, userName, password, userHash));
        }

        public bool UpdateWebsiteInCredential(string userHash, string userName, string password, string oldWebsite, string newWebsite)
        {
            CredentialEntity oldEntity = new CredentialEntity(oldWebsite, userName, password, userHash);
            CredentialEntity newEntity = new CredentialEntity(newWebsite, userName, password, userHash);
            return _dataProvider.UpdateCredential(oldEntity, newEntity);
        }

        public bool UpdateUsernameInCredential(string userHash, string oldUserName, string password, string website, string newUserName)
        {
            CredentialEntity oldEntity = new CredentialEntity(website, oldUserName, password, userHash);
            CredentialEntity newEntity = new CredentialEntity(website, newUserName, password, userHash);
            return _dataProvider.UpdateCredential(oldEntity, newEntity);
        }

        public bool UpdatePasswordInCredential(string userHash, string userName, string oldPassword, string website, string newPassword)
        {
            CredentialEntity oldEntity = new CredentialEntity(website, userName, oldPassword, userHash);
            CredentialEntity newEntity = new CredentialEntity(website, userName, newPassword, userHash);
            return _dataProvider.UpdateCredential(oldEntity, newEntity);
        }
        #endregion
    }
}
