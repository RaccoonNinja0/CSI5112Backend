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

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(string id) {
        var product = await _productService.GetAsync(id);
        if (product is null) {
            return NotFound();
        }
        return product;
    }

    [HttpPost()]
    public async Task<ActionResult> Post(Product newProduct) {
        await _productService.CreateAsync(newProduct);
        return CreatedAtAction(nameof(Get), new {id = newProduct.Id}, newProduct);
    }

    [HttpPut()]
    public async Task<ActionResult> Update(Product updatedProduct) {
        bool updated = await _productService.UpdateAsync(updatedProduct);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id) {
        var proudcts = await _productService.GetAsync(id);
        if (proudcts is null) {
            return NotFound();
        }
        await _productService.DeleteAsync(proudcts.Id);
        return NoContent();
    }

}