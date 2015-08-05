using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Models
{
    public class AddPost
    {
        public int idBlog { get; set; } /* id блога для нового поста */

        [Required]
        public string Title { get; set; } /* заголовок нового поста */

        [Required]
        public string ShortDescription { get; set; } /* короткое описание нового поста */

        [Required]
        public string Description { get; set; } /* текст нового поста */
    }
}