using System.Collections.Generic;
using System.Threading.Tasks;
using JobScheduler.Api.Models;
using MongoDB.Driver;

namespace JobScheduler.Api
{
    public class DataAccess
    {
        private readonly IMongoDatabase _db;
 
        public DataAccess()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("scheduling");      
        }
 
        public async Task<IEnumerable<Classification>> GetClassifications()
        {
            return await (await _db.GetCollection<Classification>("classifications").FindAsync(_ => true))?.ToListAsync();
        }
    }
}