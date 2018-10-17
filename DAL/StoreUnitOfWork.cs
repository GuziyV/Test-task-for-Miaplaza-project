using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StoreUnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, object> repositories;

        public StoreUnitOfWork()
        {
            
        }

        public IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class
        {
            if (typeof(TEntity) == typeof(StoreItem))
            {
                return (IRepository<TEntity, TIdentifier>)StoreItemRepository;
            }

            else
            {
                throw new TypeAccessException("Wrong type of repo");
            }
        }

        private StoreItemRepository storeItemRepository;
        public IRepository<StoreItem, string> StoreItemRepository
        {
            get
            {
                if (storeItemRepository == null)
                {
                    storeItemRepository = new StoreItemRepository();
                }
                return storeItemRepository;
            }
        }


        public void SaveChanges() //Nothing to save because we haven't DB connected to this project 
        {
            throw new NotImplementedException();
        }
    }
}
