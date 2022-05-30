using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Data
{
    public class ProductService : IProductService
    {
        private IStockData _stockData;

        public ProductService(IStockData stockData)
        {
            _stockData = stockData;
            _stockData.LoadProducts();
            _stockData.LoadInventory();
        }
        public void AddProduct(Product newProduct)
        {
            StockData.products.Add(newProduct);
        }

        //Sell a product and update the inventory accordingly
        public void SellProduct(int id)
        {
            var product = StockData.products.FirstOrDefault(x => x.Id == id);            
            if(product != null)
            {                
                foreach (var productPart in product.ContainArticles)
                {
                    var article = StockData.inventory.FirstOrDefault(x => x.ArtId == productPart.ArtId);
                    article.Stock -= productPart.AmountOf; 
                }
                StockData.products.Remove(product);
            }
            _stockData.SaveInventory();
            _stockData.SaveProducts();
        }

        //Delet a product 
        public void DeleteProduct(int id)
        {
            var product = StockData.products.FirstOrDefault(x => x.Id == id);            
            StockData.products.Remove(product);
        }

        public List<Product> GetAllProducts()
        {
            return StockData.products.ToList();
        }

        public Product GetProductById(int id)
        {
            return StockData.products.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateProduct(int id, Product newProduct)
        {
            var oldProduct = StockData.products.FirstOrDefault(x => x.Id == id);
            if(oldProduct != null)
            {
                oldProduct.Name = newProduct.Name;
                oldProduct.Price = newProduct.Price;
                oldProduct.ContainArticles = newProduct.ContainArticles;
            }
        }
    }
}
