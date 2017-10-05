using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobScheduler.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace JobScheduler.Api.Infrastructure
{
    public class DataAccess
    {
        private const string CollectionName = "classifications";
        private readonly IMongoDatabase _db;
 
        public DataAccess()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("scheduling");      
        }
 
        public async Task<IEnumerable<Classification>> GetClassifications()
        {
            var classifications = await (await _db.GetCollection<Classification>(CollectionName)
                .FindAsync(_ => true))
                ?.ToListAsync();
            return classifications;
        }

        public async Task<Classification> GetClassification(string id)
        {
            ObjectId objectId;
            try
            {
                objectId = new ObjectId(id);
            }
            catch(Exception)
            {
                return null;
            } 
            var classification = await (await _db.GetCollection<Classification>(CollectionName)
                .FindAsync(x => x.Id == objectId))
                ?.SingleOrDefaultAsync();
            return classification;
        }

        public async Task<Classification> InsertClassification(Classification classification)
        {
            await _db.GetCollection<Classification>(CollectionName).InsertOneAsync(classification);
            return classification;
        }

        public async Task UpdateClassification(string id, Classification classification)
        {
            ObjectId objectId;
            try
            {
                objectId = new ObjectId(id);
            }
            catch(Exception)
            {
                return;
            }
            if(classification == null) return;
            await _db.GetCollection<Classification>(CollectionName).ReplaceOneAsync(x => x.Id == objectId, classification);
        }

        public async Task<Classification> DeleteClassification(string id)
        {
            ObjectId objectId;
            try
            {
                objectId = new ObjectId(id);
            }
            catch(Exception)
            {
                return null;
            }
            var classification = await GetClassification(id);
            await _db.GetCollection<Classification>(CollectionName).DeleteOneAsync(x => x.Id == objectId);
            return classification;
        }
    }
}