using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Data
{
    public interface IStockData
    {
        public void LoadProducts();
        public void LoadInventory();
        public void SaveProducts();
        public void SaveInventory();
    }
}
