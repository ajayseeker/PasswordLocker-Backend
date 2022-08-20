using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLib.Infrasturcture
{
    public class CredentialInfo
    {
        public CredentialInfo(string userName, string password, string website)
        {
            UserName = userName;
            Password = Password;
            WebSite = website;
        }

        public CredentialInfo()
        {
            UserName = string.Empty;
            Password = string.Empty;
            WebSite = string.Empty;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string WebSite { get; set; }
    }
}
