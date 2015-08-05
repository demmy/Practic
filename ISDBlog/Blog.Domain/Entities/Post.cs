using System;
using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class Post
    {
        public virtual int Id { get; set; } /* id поста */
        public virtual string Title { get; set; } /* заголовок поста */
        public virtual string ShortDescription { get; set; } /* короткое описание поста */
        public virtual string Description { get; set; } /* текст поста */
        public virtual DateTime PostedOn { get; set; } /* дата поста */
        public virtual User User { get; set; } /* автор поста */
        public virtual BlogModel Blog { get; set; } /* блог которому принадлежит пост */
        public virtual IEnumerable<Comment> Comments { get; set; } /* коллекция комментариев поста */
    }
}
