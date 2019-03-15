using System.ComponentModel.DataAnnotations;

namespace DMGM.Api.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Proivde valid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 8, MinimumLength = 4, ErrorMessage = "Password should be between 4 and 8 characters")]
        public string Password { get; set; }
    }
}
