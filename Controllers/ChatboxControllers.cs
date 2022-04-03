using csi5112service.models;
using csi5112service.services;
using Microsoft.AspNetCore.Mvc;

namespace csi5112service.controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatBoxController : ControllerBase{
    private readonly ChatboxService _chatboxService;
    public ChatBoxController(ChatboxService chatboxService){
        this._chatboxService = chatboxService;
    }

    [HttpGet]
    public async Task<List<Chatbox>> Get() {
        return await _chatboxService.GetAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Chatbox>> Get(string id) {
        var post = await _chatboxService.GetAsync(id);
        if (post is null) {
            return NotFound();
        }
        return post;
    }

    [HttpPost()]
    public async Task<ActionResult> Post(Chatbox newPost) {
        await _chatboxService.CreateAsync(newPost);
        return CreatedAtAction(nameof(Get), new {id = newPost.Id}, newPost);//可能有问题：这个new 后面的id 是Id 还是id？
    }

    [HttpPut()]
    public async Task<ActionResult> Update(Chatbox updatedPost) {
        bool updated = await _chatboxService.UpdateAsync(updatedPost);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 
        return NoContent();
    }

}