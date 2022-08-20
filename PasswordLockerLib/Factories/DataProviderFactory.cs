using PasswordLockerLib.Interfaces;
using PasswordLockerLib.PersistanceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PasswordLockerLib.Infrasturcture.Utilities;

namespace PasswordLockerLib.Infrasturcture
{
    public class DataProviderFactory
    {
        public static IAuthenticateDataProvider GetAuthenticateDataProvider(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.MongoDB:
                return new AuthenticationDataTransferServiceMongoDb();

                case DatabaseType.Sql:
                    return null;
            }
            return null;
        }
        public static ICredentialsDataTransfer GetCredentialsDataProvider(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.MongoDB:
                    return new CredentialsDataTransferServiceMongoDb();

                case DatabaseType.Sql:
                    return null;
            }
            return null;
        }
    }
}
