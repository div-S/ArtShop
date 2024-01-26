using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ArtShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(500)]
        public ActionResult GetProducts()
        {
            try
            {
                var products = _repository.GetProduct();
                return Ok(products);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult GetProduct(int id)
        {
            try
            {
                var product =  _repository.GetProductById(id);
                return product == null ? NotFound() : Ok(product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpGet("categories")]
        [ProducesResponseType(typeof(ProductCategory), 200)]
        [ProducesResponseType(500)]
        public ActionResult GetProductCategories()
        {
            try
            {
                var categories = _repository.GetProductCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        //public async Task<ActionResult<List<Product>>> GetProducts()
        //{
        //    try
        //    {
        //        var products = await _repository.GetProductAsync();
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(500, ex);
        //    }
        //}



        //public async Task<ActionResult<Product>> GetProduct(int id) 
        //{
        //    try
        //    {
        //        return await _repository.GetProductByIdAsync(id);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(500, ex);
        //    }
        //}
    }
}
