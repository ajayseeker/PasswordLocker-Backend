using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordLockerLibrary
{
    public interface IAuthenticate
    {
        bool RegisterUser(string userName, string password);
        bool IsUserNamePasswordValid(string userName, string password);
    }
}
