using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.WebUI.Models
{
    public class BlogsUserListViewModel
    {
        public IEnumerable<BlogModel> Blogs { get; set; } /* Блоги пользователя */
        public PagingInfo PagingInfo { get; set; } /* информация о навигации */
    }
}