using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Data
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProduct(int id, Product newProduct);
        public void SellProduct(int id);
        void DeleteProduct(int id);
        void AddProduct(Product newProduct);
    }
}
