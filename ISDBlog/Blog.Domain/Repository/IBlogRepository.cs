using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Abstract
{
    public interface IBlogRepository
    {
        IEnumerable<BlogModel> ListBlogs { get; } /* коллекция блогов */
        IEnumerable<Post> ListPosts { get; } /* коллекция постов */
        IEnumerable<User> ListUsers { get; } /* коллекция пользователей */
        IEnumerable<Post> PostsBlog(BlogModel blog); /* коллекция постов, определённого блога */
        Post Post(int idPost); /* конкретный пост */
        void AddUser(User user); /* добавление пользователя в БД */
        void AddBlog(BlogModel blog); /* добавление блога в БД */
        void AddPost(Post post); /* добавление поста в БД */
        void AddComment(Comment comment); /* добавление комментария в БД */
    }
}
