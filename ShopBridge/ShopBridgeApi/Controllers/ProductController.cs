using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeApi.Entity;
using ShopBridgeApi.Models;
using ShopBridgeApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController:ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        //Injecting the Constructor with the instances of required services
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //Using IProductRepository to get all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var productEntities = _productRepository.GetProducts();
                return Ok(_mapper.Map<IEnumerable<ProductModel>>(productEntities));
            }            
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Using IProductRepository to get a product
        [HttpGet("{id}", Name = "GetExistingProduct")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var productEntity = _productRepository.GetProduct(id);
                if (productEntity == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<ProductModel>(productEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Create method using IproductRepository for creating a product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] EditProduct product)
        {
            try
            {
                if (product.Description == product.Name)
                {
                    ModelState.AddModelError("Description", "Name and Description fields cannot be same");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var createdProduct = _mapper.Map<Product>(product);
                _productRepository.AddProduct(createdProduct);
                _productRepository.Save();
                var newProduct = _mapper.Map<Models.ProductModel>(createdProduct);
                return CreatedAtRoute("GetExistingProduct", new { newProduct.Id }, newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Update method using patch update to update required parts of the product by using IProducctRepository 
        [HttpPatch("{id}")]
        public IActionResult EditProduct(int id, [FromBody] JsonPatchDocument<EditProduct> patchDoc)
        {
            try
            {
                if (!_productRepository.ProductExist(id))
                {
                    return NotFound();
                }

                var existingProduct = _productRepository.GetProduct(id);

                var productToPatch = _mapper.Map<EditProduct>(existingProduct);
                patchDoc.ApplyTo(productToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _mapper.Map(productToPatch, existingProduct);
                _productRepository.Save();

                return NoContent();
            }            
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Delete Method using IProductRepository to delete a product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                if (!_productRepository.ProductExist(id))
                {
                    return NotFound();
                }
                var existingProduct = _productRepository.GetProduct(id);
                _productRepository.DeleteProduct(existingProduct);
                _productRepository.Save();
                return NoContent();
            }           
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
