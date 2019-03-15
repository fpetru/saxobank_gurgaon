using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_webApp.Services
{
    public interface IRepositoryService<TEntity, in TPk> where TEntity:class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        bool Update(TPk id, TEntity entity);
        bool Delete(TPk id);
    }
}
