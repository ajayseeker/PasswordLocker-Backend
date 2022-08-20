using PasswordLockerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLib.Interfaces
{
    public interface ICredentialsDataTransfer
    {
        List<CredentialEntity> GetCredentials(string userHash);
        bool AddCredential(CredentialEntity credential);
        bool RemoveCredential(CredentialEntity credential);
        bool UpdateCredential(CredentialEntity oldCredential, CredentialEntity newCredential);
        bool AreCredentialPresent(CredentialEntity credential);
    }
}
