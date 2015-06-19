using System.Collections.Generic;
using DgdaBackend.Entities;

namespace DGDABackend.DataLayer
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(string name, Product product);
        void DeleteProduct(string name);
    }
}