using Microsoft.EntityFrameworkCore; using UserManagementAPI.Models;
namespace UserManagementAPI.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) { public DbSet<User> Users => Set<User>(); protected override void OnModelCreating(ModelBuilder b) { b.Entity<User>().HasIndex(x=>x.Email).IsUnique(); } }