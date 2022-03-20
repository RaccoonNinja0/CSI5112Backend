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

    [HttpGet("{postId}")]
    public async Task<ActionResult<Chatbox>> Get(string postId) {
        var post = await _chatboxService.GetAsync(postId);
        if (post is null) {
            return NotFound();
        }
        return post;
    }

    [HttpPost("{postId}")]
    public async Task<ActionResult> Post(Chatbox newPost) {
        await _chatboxService.CreateAsync(newPost);
        return CreatedAtAction(nameof(Get), new {postId = newPost.PostId}, newPost);
    }

    [HttpPut("{postId}")]
    public async Task<ActionResult> Update(string postId, Chatbox updatedPost) {
        bool updated = await _chatboxService.UpdateAsync(postId, updatedPost);
        if (!updated) {
            // this assumes that a failed update is always caused by the object 
            // not being found. This needs to be changed if the cause may be different
            return NotFound();
        } 
        return NoContent();
    }

    [HttpDelete("{postId}")]
    public async Task<ActionResult> Delete(string PostId) {
        var todo = await _chatboxService.GetAsync(PostId);
        if (todo is null) {
            return NotFound();
        }
        await _chatboxService.DeleteAsync(todo.PostId);
        return NoContent();
    }

}