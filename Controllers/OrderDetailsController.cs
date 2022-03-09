using csi5112service.models;
using csi5112service.services;

using Microsoft.AspNetCore.Mvc;

namespace csi5112service.controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase{
    private readonly OrderDetailsService _orderDetailsService;
    public OrderDetailsController (OrderDetailsService ods){
        this._orderDetailsService = ods;
    }

    [HttpGet]
    public async Task<List<OrderDetails>> Get() {
        return await _orderDetailsService.GetAsync();
    }

    [HttpGet("{OrderId}")]
    public async Task<ActionResult<OrderDetails>> Get(string OrderId) {
        var od = await _orderDetailsService.GetAsync(OrderId);
        if (od is null) {
            return NotFound();
        }
        return od;
    }


    [HttpPost("{OrderId}")]
    public async Task<ActionResult> Post(OrderDetails newProduct) {
        await _orderDetailsService.CreateAsync(newProduct);
        return CreatedAtAction(nameof(Get), new {productId = newProduct.ProductId}, newProduct);
    }

    [HttpPut("{OrderId}")]
    public async Task<ActionResult> Update(string OrderId, OrderDetails updatedOD) {
        bool updated = await _orderDetailsService.UpdateAsync(OrderId, updatedOD);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 
        return NoContent();
    }

    [HttpDelete("{OrderId}")]
    public async Task<ActionResult> Delete(string OrderId) {
        var todo = await _orderDetailsService.GetAsync(OrderId);
        if (todo is null) {
            return NotFound();
        }
        await _orderDetailsService.DeleteAsync(todo.OrderId);
        return NoContent();
    }

}