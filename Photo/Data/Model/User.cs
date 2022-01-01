using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Photo.Model
{
    public class User : IdentityUser
    {

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

    }
}