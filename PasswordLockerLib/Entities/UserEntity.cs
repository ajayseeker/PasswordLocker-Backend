using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordLockerLibrary.Entities
{
    public class UserEntity
    {
        public UserEntity(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
