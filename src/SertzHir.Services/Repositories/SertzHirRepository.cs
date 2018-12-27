using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SertzHir.Core.Interfaces;

namespace SertzHir.Services.Repositories
{
    public class SertzHirRepository<TEntity>:ISertzHirRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Db;

        public SertzHirRepository(DbContext db)
        {
            Db = db;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }

        public TEntity GetById(int Id)
        {
            return Db.Set<TEntity>().Find(Id);
        }

        public TEntity Add(TEntity entity)
        {
            return Db.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Db.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Remove(int Id)
        {
            TEntity entity=Db.Set<TEntity>().Find(Id);
            this.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            Db.Set<TEntity>().Remove(entity);
        }
    }
}
