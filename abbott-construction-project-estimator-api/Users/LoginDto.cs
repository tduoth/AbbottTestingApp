using System.ComponentModel.DataAnnotations;

namespace ProjectEstimator.Api.Users
{
    public class LoginDto
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}