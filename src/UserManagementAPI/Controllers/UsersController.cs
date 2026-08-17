using Microsoft.AspNetCore.Mvc; using Microsoft.EntityFrameworkCore; using UserManagementAPI.Data; using UserManagementAPI.DTOs; using UserManagementAPI.Models;
namespace UserManagementAPI.Controllers;
[ApiController][Route("api/[controller]")] public class UsersController(AppDbContext db):ControllerBase {
 [HttpGet] public async Task<ActionResult<IEnumerable<User>>> GetAll()=>Ok(await db.Users.AsNoTracking().ToListAsync());
 [HttpGet("{id:int}")] public async Task<ActionResult<User>> Get(int id){var u=await db.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id); return u is null?NotFound():Ok(u);}
 [HttpPost] public async Task<ActionResult<User>> Create(CreateUserRequest r){if(await db.Users.AnyAsync(x=>x.Email==r.Email)) return Conflict(new{message="Email already exists"}); var u=new User{Name=r.Name.Trim(),Email=r.Email.Trim().ToLowerInvariant(),Role=r.Role.Trim()}; db.Users.Add(u); await db.SaveChangesAsync(); return CreatedAtAction(nameof(Get),new{id=u.Id},u);}
 [HttpPut("{id:int}")] public async Task<IActionResult> Update(int id,UpdateUserRequest r){var u=await db.Users.FindAsync(id); if(u is null)return NotFound(); if(await db.Users.AnyAsync(x=>x.Email==r.Email && x.Id!=id))return Conflict(new{message="Email already exists"}); u.Name=r.Name.Trim();u.Email=r.Email.Trim().ToLowerInvariant();u.Role=r.Role.Trim();await db.SaveChangesAsync();return Ok(u);}
 [HttpDelete("{id:int}")] public async Task<IActionResult> Delete(int id){var u=await db.Users.FindAsync(id);if(u is null)return NotFound();db.Users.Remove(u);await db.SaveChangesAsync();return NoContent();}
}