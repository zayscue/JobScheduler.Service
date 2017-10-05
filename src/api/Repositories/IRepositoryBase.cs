using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobScheduler.Api.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class 
    {
        Task<TEntity> Remove(object id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(object id);
        Task<TEntity> Insert(TEntity entity);
        Task Update(object id, TEntity entity);
    }
}