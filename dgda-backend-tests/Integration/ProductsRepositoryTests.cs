using System;
using System.IO;
using System.Linq;
using DgdaBackend.Entities;
using Xunit;
using DGDABackend.DataLayer;
using Microsoft.Framework.Runtime;
using Moq;

namespace DGDABackendTests
{
    public class ProductsRepositoryTests
    {
        [Fact]
        public void GetProducts_WithNoFile_DoesntError()
        {
            var sut = Setup();

            var products = sut.GetProducts();

            Assert.NotNull(products);
            Assert.Empty(products);
        }

        [Fact]
        public void AddProduct_WithValidData_IsSuccessful()
        {
            var sut = Setup();

            var product = new Product {Description = "desc", InStock = true, Name = "name", Price = 7};
            sut.AddProduct(product);
            var savedProduct = sut.GetProducts().Single(p => p.Name == "name");

            Assert.NotNull(product);
            Assert.Equal(product, savedProduct);
        }

        [Fact]
        public void UpdateProduct_WithValidData_IsSuccessful()
        {
            var sut = Setup();

            var product = new Product { Description = "desc", InStock = true, Name = "name", Price = 7 };
            sut.AddProduct(product);
            var updatedProduct = new Product { Description = "desc", InStock = true, Name = "new name", Price = 7 };
            sut.UpdateProduct("name", updatedProduct);

            var savedProduct = sut.GetProducts().Single(p => p.Name == "new name");

            Assert.NotNull(product);
            Assert.Equal(updatedProduct, savedProduct);
        }

        [Fact]
        public void DeleteProduct_WithValidData_IsSuccessful()
        {
            var sut = Setup();

            var product = new Product { Description = "desc", InStock = true, Name = "name", Price = 7 };
            sut.AddProduct(product);
            sut.DeleteProduct(product.Name);
            var products = sut.GetProducts();
            
            Assert.Empty(products);
        }

        private ProductsRepository Setup()
        {
            var mockAppEnv = new Mock<IApplicationEnvironment>();
            mockAppEnv.Setup(a => a.ApplicationBasePath).Returns(AppDomain.CurrentDomain.BaseDirectory);
            var path = mockAppEnv.Object.ApplicationBasePath + "products.json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            return new ProductsRepository(mockAppEnv.Object);
        }
    }
}
