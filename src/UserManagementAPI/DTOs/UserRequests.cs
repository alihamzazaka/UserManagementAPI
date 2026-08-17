using System.ComponentModel.DataAnnotations;
namespace UserManagementAPI.DTOs;
public record CreateUserRequest([Required, StringLength(100, MinimumLength=2)] string Name,[Required, EmailAddress] string Email,[Required, StringLength(100)] string Role);
public record UpdateUserRequest([Required, StringLength(100, MinimumLength=2)] string Name,[Required, EmailAddress] string Email,[Required, StringLength(100)] string Role);