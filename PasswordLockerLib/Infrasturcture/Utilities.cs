using PasswordLockerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLib.Infrasturcture
{
    public class Utilities
    {
        public enum Collections
        {
            UserInfo,
            Credentials
        }
        public enum DatabaseType
        {
            MongoDB,
            Sql
        }
        public enum LogCategory
        {
            Trace,
            Exception,
            Information,
            Warning,
            Errors
        }
        public static CredentialInfo ConvertCredentialEntityToCredentialInfo(CredentialEntity credentialEntity)
        {
            return new CredentialInfo(credentialEntity.UserName, credentialEntity.Password, credentialEntity.Password);
        }
    }
}
