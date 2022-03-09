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

    [HttpGet("{UserId}")]

    public async Task<ActionResult<User>> Get(string UserId){
        var user = await _userService.GetAsync(UserId);
        if(User is null){
            return NotFound();
        }
        return user;
    }

    [HttpPost("{UserId}")]
    public async Task<ActionResult> Post(User newUser){
        await _userService.CreateAsync(newUser);
        return CreatedAtAction(nameof(Get),new {UserId = newUser.UserId}, newUser);
    }

    [HttpPut("{UserId}")]
    public async Task<ActionResult> Update(string UserId, User updatedUser){
        var user = await _userService.GetAsync(UserId);
        if (user is null){
            return NotFound();
        }
        updatedUser.UserId = user.UserId;
       
        await _userService.UpdateAsync(UserId, updatedUser);

        return NoContent();
    }

    [HttpDelete("{UserId}")]
    public async Task<ActionResult> Delete(string UserId){
        var user = await _userService.GetAsync(UserId);
        if (user is null){
            return NotFound();
        }
         await _userService.DeleteAsync(user.UserId);
         return NoContent();
    }

    
}