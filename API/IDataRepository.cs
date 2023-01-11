using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CropAPI.Repository
{
    internal interface IDataRepository<TEntity>
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Update(TEntity dbEntity);
        void Delete(int entity);
       // void SaveChanges();
    }
}