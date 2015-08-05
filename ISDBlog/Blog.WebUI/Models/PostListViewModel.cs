using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.WebUI.Models
{
    public class PostListViewModel
    {
        public IEnumerable<Post> Posts { get; set; } /* коллекция постов */
        public PagingInfo PagingInfo { get; set; } /* информация о навигации */
    }
}