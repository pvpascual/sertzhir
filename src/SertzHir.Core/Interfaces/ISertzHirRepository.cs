using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.Interfaces
{
    public interface ISertzHirRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int Id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int Id);
        void Remove(TEntity entity);
       
    }
}
