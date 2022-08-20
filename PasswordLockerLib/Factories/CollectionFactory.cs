using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PasswordLockerLib.Infrasturcture.Utilities;

namespace PasswordLockerLib.Infrasturcture
{
    public class CollectionFactory
    {
        public CollectionFactory()
        {
        }

        static private MongoClient _mongoClient = new MongoClient(Config.ConnectionString);
        static private IMongoDatabase _db = _mongoClient.GetDatabase(Config.PasswordLocker);
        static public IMongoCollection<T> GetCollection<T>(Collections collection)
        {
            try
            {
                return _db.GetCollection<T>(collection.ToString());
            }
            catch(Exception ex)
            {

            }
            return null;
        }
        
    }
}
