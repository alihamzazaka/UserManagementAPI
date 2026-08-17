using Microsoft.EntityFrameworkCore; using UserManagementAPI.Data; using UserManagementAPI.Middleware;
var builder=WebApplication.CreateBuilder(args); builder.Services.AddControllers(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen(); builder.Services.AddDbContext<AppDbContext>(o=>o.UseInMemoryDatabase("UserManagementDb"));
var app=builder.Build(); if(app.Environment.IsDevelopment()){app.UseSwagger();app.UseSwaggerUI();} app.UseHttpsRedirection(); app.UseMiddleware<RequestLoggingMiddleware>(); app.MapControllers(); app.Run();
public partial class Program {}