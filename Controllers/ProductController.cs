using csi5112service.models;
using csi5112service.services;
using Microsoft.AspNetCore.Mvc;

namespace csi5112service.controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase{
    private readonly ProductService _productService;
    public ProductController(ProductService productService){
        this._productService = productService;
    }

    [HttpGet]
    public async Task<List<Product>> Get() {
        return await _productService.GetAsync();
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<Product>> Get(string productId) {
        var product = await _productService.GetAsync(productId);
        if (product is null) {
            return NotFound();
        }
        return product;
    }

    [HttpPost("{productId}")]
    public async Task<ActionResult> Post(Product newProduct) {
        await _productService.CreateAsync(newProduct);
        return CreatedAtAction(nameof(Get), new {productId = newProduct.ProductId}, newProduct);
    }

    [HttpPut("{productId}")]
    public async Task<ActionResult> Update(string productId, Product updatedProduct) {
        bool updated = await _productService.UpdateAsync(productId, updatedProduct);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 
        return NoContent();
    }

    [HttpDelete("{productId}")]
    public async Task<ActionResult> Delete(string ProductId) {
        var todo = await _productService.GetAsync(ProductId);
        if (todo is null) {
            return NotFound();
        }
        await _productService.DeleteAsync(todo.ProductId);
        return NoContent();
    }

}