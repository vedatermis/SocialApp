using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Dto;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly SocialContext _socialContext;

        public ProductsController(SocialContext socialContext)
        {
            _socialContext = socialContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _socialContext.Products
                .Select(s => ProductToDTO(s))
                .ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _socialContext.Products.Select(s => ProductToDTO(s)).FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            _socialContext.Products.Add(entity);
            await _socialContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = entity.ProductId }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product entity)
        {
            if (id != entity.ProductId)
            {
                return BadRequest();
            }

            var product = await _socialContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = entity.Name;
            product.Price = entity.Price;

            try
            {
                await _socialContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var product = await _socialContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _socialContext.Products.Remove(product);
            await _socialContext.SaveChangesAsync();

            return NoContent();
        }

        private static ProductDto ProductToDTO(Product p)
        {
            return new ProductDto { ProductId = p.ProductId, Name = p.Name, Price = p.Price, IsActive = p.IsActive };
        }
    }
}