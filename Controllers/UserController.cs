using Microsoft.AspNetCore.Mvc;
using User_solution.Data;
using User_solution.Data.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace ReactDemo.API.Controllers;
 
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly User_solutionContext _User_solutionContext;
    public UserController(User_solutionContext user_solutionContext)
    {
        _User_solutionContext = user_solutionContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _User_solutionContext.Users.ToListAsync();
        return Ok(user);
    }

    [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var user = await _User_solutionContext.Users.FindAsync(id);
            if (user == null)
            {
               return NotFound();
            }
        return Ok(user);
    }  

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        _User_solutionContext.Users.Add(newUser);
        await _User_solutionContext.SaveChangesAsync();
        return Ok(newUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _User_solutionContext.Users.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        _User_solutionContext.Users.Remove(entity);
        await _User_solutionContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] User bodyUser)
    {
        if (id != bodyUser.Id)
        {
            return BadRequest();
        }

        User userToUpdate = bodyUser;

        _User_solutionContext.Entry(userToUpdate).State = EntityState.Modified;

        await _User_solutionContext.SaveChangesAsync();
       

        return NoContent();
    }

}
