using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DgdaBackend.Entities;
using Microsoft.Framework.Runtime;
using Newtonsoft.Json;

namespace DGDABackend.DataLayer
{
    public class ProductsRepository : IProductsRepository
    {
        private List<Product> _products;
        private readonly string _productsPath;

        public ProductsRepository(IApplicationEnvironment env)
        {
            _productsPath = env.ApplicationBasePath + "/products.json";

            if (!File.Exists(_productsPath))
            {
                var stream = File.Create(_productsPath);
                stream.Dispose();
            }

            _products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(_productsPath)) ??
                        new List<Product>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (product.Name == null) throw new ArgumentNullException(nameof(product.Name));
            if (_products.Any(p => p.Name.Equals(product.Name))) throw new ArgumentException("Product already exists.");

            _products.Add(product);

            PersistProducts();
        }

        public void UpdateProduct(string name, Product product)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (!_products.Any(p => p.Name.Equals(name))) throw new NotFoundException("Product not found.");

            _products = _products.Where(p => !p.Name.Equals(name)).ToList();
            _products.Add(product);

            PersistProducts();
        }

        public void DeleteProduct(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            _products = _products.Where(p => !p.Name.Equals(name)).ToList();

            PersistProducts();
        }

        private void PersistProducts()
        {
            File.WriteAllText(_productsPath, JsonConvert.SerializeObject(_products));
        }
    }
}
