using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; } /* email нового пользователя */

        [Required]
        public string Name { get; set; } /* имя нового пользователя */

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } /* пароль нового пользователя */

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; } /* подтверждение пароля */
    }
}