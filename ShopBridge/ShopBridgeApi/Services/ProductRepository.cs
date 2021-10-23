using ShopBridgeApi.Context;
using ShopBridgeApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Services
{
    //Implements Interface IProductRepository
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {            
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));            
        }
        public void AddProduct(Product product)
        {
            _productContext.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _productContext.Products.Remove(product);
        }

        public Product GetProduct(int productId)
        {
            return _productContext.Products.Where(m => m.Id == productId).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productContext.Products.OrderBy(m => m.Name).ToList();
        }

        public bool ProductExist(int productId)
        {
            return _productContext.Products.Any(m => m.Id == productId);
        }

        public bool Save()
        {
            return (_productContext.SaveChanges() >= 0);
        }

        public void UpdateProduct()
        {

        }
    }
}
