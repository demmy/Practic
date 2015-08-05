using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class User
    {
        public virtual int Id { get; set; } /* id пользователя */
        public virtual string Name { get; set; } /* имя пользователя */
        public virtual string Email { get; set; } /* email пользователя */
        public virtual string Password { get; set; } /* пароль пользователя */
        public virtual IEnumerable<Comment> Comments { get; set; } /* коллекция комментариев пользователя */
        public virtual IEnumerable<Post> Posts { get; set; } /* коллекция постов пользователя */
        public virtual IEnumerable<BlogModel> Blogs { get; set; } /* коллекция блогов пользователя */
    }
}
