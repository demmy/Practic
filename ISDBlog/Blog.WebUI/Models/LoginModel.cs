using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; } /* email пользователя */

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } /* пароль пользователя */
    }
}