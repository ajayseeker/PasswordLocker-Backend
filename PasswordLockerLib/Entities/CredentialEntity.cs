using System;

namespace PasswordLockerLibrary
{
    public class CredentialEntity
    {
        public CredentialEntity(string site, string userName, string password, string userHash)
        {
            WebSite = site;
            UserName = userName;
            Password = password;
            UserHash = userHash;
        }
        public string UserHash { get; set; }
        public string WebSite { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
