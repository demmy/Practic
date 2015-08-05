using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.WebUI.Models
{
    public class BlogListViewModel
    {
        public IEnumerable<BlogModel> Blogs { get; set; } /* коллекция блогов */
        public PagingInfo PagingInfo { get; set; } /* информация о навигации */
    }
}