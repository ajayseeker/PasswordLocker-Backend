using PasswordLockerLib.Factories;
using PasswordLockerLib.Infrasturcture;
using PasswordLockerLib.Interfaces;
using PasswordLockerLib.PersistanceServices;
using PasswordLockerLib.Services;
using PasswordLockerLibrary;
using PasswordLockerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLockerLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //EncryptionTest();
            //MongoDBTest();
            LogTest();
            //AuthenticateServiceTest();
            //CredentialsServiceTest();
            Console.ReadLine();
        }
        static void LogTest()
        {
            Logger.Log(Utilities.LogCategory.Errors, "Unknown error occured");
            try
            {
                int zero = 0;
                int num = 12 / zero;
            }
            catch(Exception ex)
            {
                Logger.Log(Utilities.LogCategory.Exception, ex.Message);
            }
            Logger.Log(Utilities.LogCategory.Errors, "Unknown error occured");
            Logger.Log(Utilities.LogCategory.Trace, "Exception and Error Trace done");
            Logger.Log(Utilities.LogCategory.Warning, "I'm feeling sleepy");

        }
        static void CredentialsServiceTest()
        {
            ServiceFactory serviceFactory = new ServiceFactory();
            ICRUDCredentials credentialService = serviceFactory.GetCredentialService();

            Console.WriteLine(credentialService.AddCredential("ajay#AB", "AjaySingh", "Password", "www.Amazon.com"));
            Console.WriteLine(credentialService.AddCredential("ajaySingh#ABC", "AjaySingh", "Password", "www.Facebook.com"));
            Console.WriteLine(credentialService.AddCredential("ajayPawar#ABCD", "AjaySingh", "Password", "www.Instagram.com"));

            Console.WriteLine(credentialService.RemoveCredential("ajayPawar#ABCD", "AjaySingh", "Password", "www.Instagram.com"));
            Console.WriteLine(credentialService.UpdateUsernameInCredential("ajaySingh#ABC", "AjaySingh", "VijaySingh", "Password", "www.Instagram.com"));
            Console.WriteLine(credentialService.UpdatePasswordInCredential("ajaySingh#ABC", "VijaySingh", "Password", "NewPassword", "www.Instagram.com"));
            Console.WriteLine(credentialService.UpdatePasswordInCredential("ajaySingh#ABC", "VijaySingh", "NewPassword", "www.Instagram.com", "www.Twitter.com"));

            foreach(var credential in credentialService.GetUserCredentials("ajayPawar#ABCD"))
            {
                Console.WriteLine(credential.UserName + ", " + credential.Password + ", " + credential.Password);
            }

        }
        static void AuthenticateServiceTest() 
        { 
            ServiceFactory serviceFactory = new ServiceFactory();
            IAuthenticate authenticationService = serviceFactory.GetAuthenticateService();

            Console.WriteLine(authenticationService.RegisterUser("Ajay257223@gmail.com", "ABCD"));
            Console.WriteLine(authenticationService.RegisterUser("Ajay257223@gmail.com", "AB"));
            Console.WriteLine(authenticationService.RegisterUser("PawarAjaySingh26@gmail.com", "AB"));
        }
        static void EncryptionTest()
        {
            IEncrypt encrypt = new EncryptionService();
            string cypherText = encrypt.Encrypt("ajay257223@gmail.com");
            string plainText = encrypt.Decrypt(cypherText);
            Console.WriteLine(cypherText);
            Console.WriteLine(plainText);
        }
    }
}
