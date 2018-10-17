using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository <TEntity, TIdentifier> where TEntity : class
    {
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        bool TryDelete(TIdentifier identifier);

        List<TEntity> GetAll();

        TEntity Get(TIdentifier identifier);
    }
}
