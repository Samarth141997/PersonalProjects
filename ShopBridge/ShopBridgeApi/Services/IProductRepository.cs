using ShopBridgeApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct();
        void DeleteProduct(Product product);
        bool Save();
        bool ProductExist(int productId);
    }
}
