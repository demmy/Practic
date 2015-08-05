using System;

namespace Blog.Domain.Entities
{
    public class Comment
    {
        public virtual int Id { get; set; } /* id комментария */
        public virtual string Description { get; set; } /* текст комментарий */
        public virtual DateTime Commented { get; set; } /* дата добавления комментария */
        public virtual User User { get; set; } /* автор комментария */
        public virtual Post Post { get; set; } /* пост к которому сделан комментарий */
    }
}
