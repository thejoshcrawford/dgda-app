using System;
using System.Collections.Generic;
using System.Linq;
using DgdaBackend.Entities;
using DGDABackend.DataLayer;
using Microsoft.AspNet.Mvc;

namespace DgdaBackend.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productsRepository.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Get(string name)
        {
            return _productsRepository.GetProducts().SingleOrDefault(p => p.Name == name);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid) return HttpBadRequest(ModelState);

            try
            {
                _productsRepository.AddProduct(product);
                return new EmptyResult();
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError("ArgumentNull", ex.Message);
                return HttpBadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Argument", ex.Message);
                return HttpBadRequest(ModelState);
            }
        }

        [HttpPut("{name}")]
        public IActionResult Put(string name, [FromBody] Product product)
        {
            if (!ModelState.IsValid) return HttpBadRequest(ModelState);

            try
            {
                _productsRepository.UpdateProduct(name, product);
                return new EmptyResult();
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError("ArgumentNull", ex.Message);
                return HttpBadRequest(ModelState);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("NotFound", ex.Message);
                return HttpBadRequest(ModelState);
            }
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            try
            {
                _productsRepository.DeleteProduct(name);
                return new EmptyResult();
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError("ArgumentNull", ex.Message);
                return HttpBadRequest(ModelState);
            }
        }
    }
}
