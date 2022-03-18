using csi5112service.models;
using csi5112service.services;
using Microsoft.AspNetCore.Mvc;

namespace csi5112service.controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController: ControllerBase{
    private readonly OrderServcie _orderService;
    public OrderController(OrderServcie orderService){
        this._orderService = orderService;
    }

    [HttpGet]
    public async Task<List<Order>> Get(){
        return await _orderService.GetAsync();
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<Order>> Get(string OrderId){
        var order = await _orderService.GetAsync(OrderId);
        if(order is null){
            return NotFound();
        }
        return order;
    }

    [HttpPost("{orderId}")]
    public async Task<ActionResult> Post(Order newOrder){
        await _orderService.CreateAsync(newOrder);
        return CreatedAtAction(nameof(Get), new {OrderId = newOrder.OrderId}, newOrder);
    }

    [HttpPut("{orderId}")]
    public async Task<ActionResult> Update(String orderId, Order updatedOrder){
        bool updated = await _orderService.UpdateAsync(orderId,updatedOrder);
        if (!updated){
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{orderId}")]
    public async Task<ActionResult> Deletes(string OrderId){
        var order = await _orderService.GetAsync(OrderId);
        if (order is null){
            return NotFound();
        }
        await _orderService.DeleteAsync(order.OrderId);
        return NoContent();
    }
}

