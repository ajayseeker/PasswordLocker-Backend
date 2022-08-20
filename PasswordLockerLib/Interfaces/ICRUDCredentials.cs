using PasswordLockerLib.Infrasturcture;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordLockerLibrary.Interfaces
{
    public interface ICRUDCredentials
    {
        List<CredentialInfo> GetUserCredentials(string userHash);
        bool AddCredential(string userHash, string userName, string password, string website);
        bool RemoveCredential(string userHash, string userName, string password, string website);
        bool UpdateWebsiteInCredential(string userHash, string userName, string password, string oldWebsite, string newWebsite);
        bool UpdateUsernameInCredential(string userHash, string oldUserName, string password, string website, string newUserName);
        bool UpdatePasswordInCredential(string userHash, string userName, string oldPassword, string website, string newPassword);
    }
}
