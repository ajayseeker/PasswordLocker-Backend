using PasswordLockerLibrary;
using PasswordLockerLibrary.Interfaces;
using PasswordLockerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLib.Factories
{
    public class ServiceFactory
    {
        public IAuthenticate GetAuthenticateService()
        {
            return new AuthenticateService();
        }
        public ICRUDCredentials GetCredentialService()
        {
            return new CredentialService();
        }
    }
}
