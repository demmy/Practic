using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Models
{
    public class AddBlog
    {
        [Required]
        public string Title { get; set; } /* заголовок нового блога*/

        [Required]
        public string Description { get; set; } /* описание нового блога */
    }
}