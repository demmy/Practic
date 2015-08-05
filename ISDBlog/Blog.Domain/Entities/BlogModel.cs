using System;
using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class BlogModel
    {
        public virtual int Id { get; set; } /* id блога */
        public virtual string Title { get; set; } /* заголовок блога */
        public virtual string Description { get; set; } /* описание к блогу */
        public virtual DateTime DateCreated { get; set; } /* дата создания блога */
        public virtual IEnumerable<Post> Posts { get; set; } /* коллекция постов блога */
        public virtual User User { get; set; } /* автор блога */
    }
}
