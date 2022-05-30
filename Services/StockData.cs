using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Data
{
    public class StockData: IStockData
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string productsFilePath = "Data\\Repo\\products.json";
        public static string inventoryFilePath = "Data\\Repo\\inventory.json";
        public static IList<Product> products;
        public static IList<Article> inventory;

        public void LoadProducts()
        {
            products = JsonFileHandler.ReadProductsFile(baseDirectory + productsFilePath);            
        }
        public void LoadInventory()
        {
            inventory = JsonFileHandler.ReadInventoryFile(baseDirectory + inventoryFilePath);            
        }

        public void SaveProducts()
        {
            JsonFileHandler.WriteToProductsFile(baseDirectory + productsFilePath, products.ToList());
        }

        public void SaveInventory()
        {
            JsonFileHandler.WriteToInventoryFile(baseDirectory + inventoryFilePath, inventory.ToList());
        }
    }
}
