using System.ComponentModel.DataAnnotations;

namespace Photo.Models.Users;

public class RegisterViewForm
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [Required]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string ConfirmPassword { get; set; }
}