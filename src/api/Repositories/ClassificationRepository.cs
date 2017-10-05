using System;
using JobScheduler.Api.Models;
using MongoDB.Driver;

namespace JobScheduler.Api.Repositories
{
    public class ClassificationRepository : RepositoryBase<Classification>
    {
        private const string CollectionName = "classifications";

        public ClassificationRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            if(db == null) throw new ArgumentNullException(nameof(db));
        }
    }
}