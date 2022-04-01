using Microsoft.AspNetCore.Mvc;
using csi5112service.services;
using csi5112service.models;
namespace csi5112service.controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase{
    

    private readonly UserService _userService; 
    public UserController(UserService userService){
       this._userService = userService;
    }

    [HttpGet] 
    public async Task<List<User>> Get(){
        return await _userService.GetAsync();
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<User>> Get(string id){
        var user = await _userService.GetAsync(id);
        if(User is null){
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<ActionResult> Post(User newUser){
        await _userService.CreateAsync(newUser);
        return CreatedAtAction(nameof(Get),new {id = newUser.Id}, newUser);
    }

    [HttpPut]
    public async Task<ActionResult> Update(User updatedUser){
        var user = await _userService.GetAsync(updatedUser.Id);
        if (user is null){
            return NotFound();
        }
        updatedUser.Id = user.Id;
       
        await _userService.UpdateAsync(updatedUser.Id, updatedUser);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id){
        var user = await _userService.GetAsync(id);
        if (user is null){
            return NotFound();
        }
         await _userService.DeleteAsync(user.Id);
         return NoContent();
    }

    
}