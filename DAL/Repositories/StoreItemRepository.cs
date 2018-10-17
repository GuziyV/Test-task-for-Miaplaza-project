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
    public class StoreItemRepository : IRepository<StoreItem, string>
    {
        private readonly List<StoreItem> storeItems;

        public StoreItemRepository()
        {
            storeItems = new List<StoreItem>();
        }

        public StoreItem Create(StoreItem entity)
        {
            storeItems.Add(entity);
            return entity;
        }

        public bool TryDelete(string identifier)
        {
            int index = storeItems.FindIndex(s => s.Name.ToLower() == identifier.ToLower());
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
            return storeItems.FirstOrDefault(s => s.Name.ToLower() == identifier.ToLower());
        }

        public StoreItem Update(StoreItem entity)
        {
            var searchItem = storeItems.FirstOrDefault(s => s.Name.ToLower() == entity.Name.ToLower());
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
