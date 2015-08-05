using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Models
{
    public class AddComment
    {
        public int idPost { get; set; } /* id поста к которому добавляем комментарий */

        [Required]
        public string Description { get; set; } /* новый комментарий */
    }
}