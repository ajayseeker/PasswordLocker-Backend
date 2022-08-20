using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PasswordLockerLib.Infrasturcture.Utilities;

namespace PasswordLockerLib.Infrasturcture
{
    public class Config
    {
        public const string ConnectionString = "mongodb://localhost:27017";
        public const string PasswordLocker = "PasswordLocker";
        public const DatabaseType AuthenticationDB = DatabaseType.MongoDB;
        public const DatabaseType CredentialDB = DatabaseType.MongoDB;
        public const string LogDir = @".\Logs\";
    }
}
