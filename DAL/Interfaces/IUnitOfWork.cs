using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class;
        void SaveChanges();
    }
}
