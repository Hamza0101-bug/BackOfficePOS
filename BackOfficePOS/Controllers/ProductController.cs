using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
           _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var Products =  await _productRepository.GetProductsAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductbyID(int id)
        {
            var Product = await _productRepository.GetProductbyIDAsync(id);
            return Ok(Product);
             ;
        }
    }
}
