using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity model);
        TEntity Update(TEntity model);
        bool Delete(TEntity model);
        void Save();
    }
}