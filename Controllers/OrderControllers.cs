using csi5112service.models;
using csi5112service.services;
using Microsoft.AspNetCore.Mvc;

namespace csi5112service.controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController: ControllerBase{
    private readonly OrderService _orderService;
    public OrderController(OrderService orderService){
        this._orderService = orderService;
    }

    [HttpGet]
    public async Task<List<Order>> Get(){
        return await _orderService.GetAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> Get(string id){
        var order = await _orderService.GetAsync(id);
        if(order is null){
            return NotFound();
        }
        return order;
    }

    [HttpPost()]
    public async Task<ActionResult> Post(Order newOrder){
        await _orderService.CreateAsync(newOrder);
        return CreatedAtAction(nameof(Get), new {id = newOrder.Id}, newOrder);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(String id, Order updatedOrder){
        bool updated = await _orderService.UpdateAsync(id,updatedOrder);
        if (!updated){
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Deletes(string id){
        var order = await _orderService.GetAsync(id);
        if (order is null){
            return NotFound();
        }
        await _orderService.DeleteAsync(order.Id);
        return NoContent();
    }
}

