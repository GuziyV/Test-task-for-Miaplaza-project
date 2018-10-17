using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StoreItem
    {
        public StoreItem(string name, decimal pricePerItem, uint count = 0)
        {
            Name = name;
            PricePerItem = pricePerItem;
            Count = count;
        }

        public string Name { get; set; }

        public decimal PricePerItem { get; set; }

        public uint Count { get; set; }

        public override string ToString()
        {
            return String.Format("{0,-3}|{1,-10}|{2:0.00,-5}", Count, Name, PricePerItem);
        }
    }
}
