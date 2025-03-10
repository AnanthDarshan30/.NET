﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;
        public ProductsController(ShopContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await _context.Products.ToArrayAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            //here we are handling errors, especially "404" not found error.
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAvailable()
        {
            return await _context.Products.Where(p => p.IsAvailable).ToArrayAsync();
        }
        [HttpPost]
        public async Task<ActionResult> PostProduct(Product product)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct", // or you can use:- nameof(GetProduct)
                new { id = product.Id },
                product);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, [FromBody]Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_context.Products.Any(p=>p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product==null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteMultiple([FromQuery]int[] ids)
        {
            var products = new List<Product>();
            foreach(var id in ids)
            {
                var product = await _context.Products.FindAsync(id);
                if(product == null)
                {
                    return NotFound();
                }

                products.Add(product);
            }

            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();

            return Ok(products);
        }
    }
}

