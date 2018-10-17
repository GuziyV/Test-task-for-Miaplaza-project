using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StoreItem
    {
        public StoreItem(string name, decimal pricePerItem, int count = 0)
        {
            Name = name;
            PricePerItem = pricePerItem;
            Count = count;
        }

        public string Name { get; set; }

        public decimal PricePerItem { get; set; }

        public int Count { get; set; }
    }
}
