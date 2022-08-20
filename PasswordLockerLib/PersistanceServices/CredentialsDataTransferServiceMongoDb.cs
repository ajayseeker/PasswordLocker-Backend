using MongoDB.Driver;
using PasswordLockerLib.Infrasturcture;
using PasswordLockerLib.Interfaces;
using PasswordLockerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLib.PersistanceServices
{
    public class CredentialsDataTransferServiceMongoDb : ICredentialsDataTransfer
    {
        public CredentialsDataTransferServiceMongoDb()
        {
            _credentialCollection = CollectionFactory.GetCollection<CredentialEntity>(Utilities.Collections.Credentials);
        }

        private IMongoCollection<CredentialEntity> _credentialCollection = null;

        #region ICredentialDataTransfer Implementation
        public bool AddCredential(CredentialEntity credential)
        {
            try
            {
                _credentialCollection.InsertOne(credential);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<CredentialEntity> GetCredentials(string userHash)
        {
            List<CredentialEntity> _credentials = new List<CredentialEntity>();
            try
            {
                _credentials = _credentialCollection.Find<CredentialEntity>(obj => obj.UserHash == userHash).ToList<CredentialEntity>();
            }
            catch(Exception ex)
            {

            }
            return _credentials;
        }

        public bool RemoveCredential(CredentialEntity credential)
        {
            try
            {
                _credentialCollection.DeleteOne(obj => obj.UserHash == credential.UserHash && obj.UserName == credential.UserName && obj.WebSite == credential.WebSite && obj.Password == credential.Password);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateCredential(CredentialEntity oldCredential, CredentialEntity newCredential)
        {
            try
            {
                _credentialCollection.ReplaceOne(obj => obj == oldCredential, newCredential);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool AreCredentialPresent(CredentialEntity entity)
        {
            try
            {
                var credentials = _credentialCollection.Find<CredentialEntity>(obj => obj == entity);
                return credentials.Any();
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
