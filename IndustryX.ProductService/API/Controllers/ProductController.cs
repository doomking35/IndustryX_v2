using IndustryX.ProductService.Core.Entities;
using IndustryX.ProductService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IndustryX.ProductService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var products = await productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await productRepository.GetByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await productRepository.AddAsync(product);
        return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        if (id != product.Id) return BadRequest();

        await productRepository.UpdateAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await productRepository.DeleteAsync(id);
        return NoContent();
    }
}
}