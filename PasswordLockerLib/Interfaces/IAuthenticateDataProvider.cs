using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLib.Interfaces
{
    public interface IAuthenticateDataProvider
    {
        bool IsUserNamePresent(string userName);
        bool AddUserInfo(string userName, string password);
        bool IsUserNameAndPasswordPresent(string userName, string password);
    }
}
