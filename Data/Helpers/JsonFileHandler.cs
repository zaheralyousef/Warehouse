using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Warehouse.Data;

namespace Warehouse.Data
{

    public static class JsonFileHandler
    {
        public static IList<Product> ReadProductsFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            var data = JsonSerializer.Deserialize<ProductsJson>(jsonString)!;

            return data.Products.ToList();           
        }

        public static IList<Article> ReadInventoryFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            var data = JsonSerializer.Deserialize<InventoryJson>(jsonString)!;

            return data.Inventory.ToList();
        }

        public static void WriteToProductsFile(string fileName, List<Product> products)
        {
            var productsJson = new Dictionary<string, Product[]>
            {
                { "Products", products.ToArray() }
            };
            string json = JsonSerializer.Serialize(productsJson);
            File.WriteAllText(fileName, json);
        }

        public static void WriteToInventoryFile(string fileName, List<Article> inventory)
        {
            var inventoryJson = new Dictionary<string, Article[]>
            {
                { "Inventory", inventory.ToArray() }
            };
            string json = JsonSerializer.Serialize(inventoryJson);
            File.WriteAllText(fileName, json);
        }
    }

}
