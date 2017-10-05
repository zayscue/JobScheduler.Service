using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace JobScheduler.Api.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        internal readonly IMongoDatabase _db;
        internal readonly string _collectionName;

        public RepositoryBase(IMongoDatabase db, string collectionName)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await (await _db.GetCollection<TEntity>(_collectionName)
                .FindAsync(_ => true))
                ?.ToListAsync();
        }

        public async Task<TEntity> GetById(object id)
        {
            ObjectId objectId;
            if(!ObjectId.TryParse(id.ToString(), out objectId)) return null;
            var idFilter = Builders<TEntity>.Filter.Eq("_id", objectId);
            return await (await _db.GetCollection<TEntity>(_collectionName).FindAsync(idFilter))?.SingleOrDefaultAsync();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await _db.GetCollection<TEntity>(_collectionName).InsertOneAsync(entity);
            return entity;
        }

        public async Task<TEntity> Remove(object id)
        {
            ObjectId objectId;
            if(!ObjectId.TryParse(id.ToString(), out objectId)) return null;
            var entity = await GetById(id);
            var idFilter = Builders<TEntity>.Filter.Eq("_id", objectId);
            await _db.GetCollection<TEntity>(_collectionName).DeleteOneAsync(idFilter);
            return entity;
        }

        public async Task Update(object id, TEntity entity)
        {
            ObjectId objectId;
            if(!ObjectId.TryParse(id.ToString(), out objectId)) return;
            var idFilter = Builders<TEntity>.Filter.Eq("_id", objectId);
            await _db.GetCollection<TEntity>(_collectionName).ReplaceOneAsync(idFilter, entity);
        }
    }
}