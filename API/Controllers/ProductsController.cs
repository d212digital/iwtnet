using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        
        private readonly IGenericRepository<ProductType> _productTypeRepo;
 
        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepo = productRepository;
            _productBrandRepo = productBrandRepository;
            _productTypeRepo = productTypeRepository;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepo.ListAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok (await _productBrandRepo.ListAllAsync());
        } 

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok (await _productTypeRepo.ListAllAsync());
        } 
    }

}