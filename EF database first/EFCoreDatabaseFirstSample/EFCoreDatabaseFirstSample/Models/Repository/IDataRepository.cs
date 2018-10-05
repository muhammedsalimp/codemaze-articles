using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample.Models.Repository
{
    public interface IDataRepository<TEntity, TDTO>
    {
        IEnumerable<TDTO> GetAll();
        TDTO Get(long id);
        TEntity GetEntity(long id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}
