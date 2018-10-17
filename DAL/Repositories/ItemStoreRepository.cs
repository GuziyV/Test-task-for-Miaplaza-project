using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class StoreItemRepository : IRepository<StoreItem, string>
    {
        private readonly List<StoreItem> storeItems;

        public StoreItemRepository()
        {
            storeItems = new List<StoreItem>();
        }

        public StoreItem CreateAsync(StoreItem entity)
        {
            storeItems.Add(entity);
            return entity;
        }

        public bool TryDelete(string identifier)
        {
            int index = storeItems.FindIndex(s => s.Name == identifier);
            if(index < 0)
            {
                return false;
            }

            storeItems.RemoveAt(index);
            return true;
        }

        public List<StoreItem> GetAll()
        {
            return storeItems;
        }

        public StoreItem Get(string identifier)
        {
            return storeItems.FirstOrDefault(s => s.Name == identifier);
        }

        public StoreItem Update(StoreItem entity)
        {
            var searchItem = storeItems.FirstOrDefault(s => s.Name == entity.Name);
            if(searchItem == null)
            {
                throw new InvalidOperationException("Item with this name doesn't exist in store");
            }
            else
            {
                searchItem = entity;
            }
            return searchItem;
        }
    }
}
