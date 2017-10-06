using System;
using JobScheduler.Api.Models;
using MongoDB.Driver;

namespace JobScheduler.Api.Repositories
{
    public class JobRequestRepository : RepositoryBase<JobRequest>
    {
        private const string CollectionName = "requests";

        public JobRequestRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            if(db == null) throw new ArgumentNullException(nameof(db));
        }
    }
}