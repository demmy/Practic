using Blog.Domain.Entities;
using FluentNHibernate.Mapping;

namespace Blog.Domain.Mappings
{
    public class BlogMap : ClassMap<BlogModel>
    {
        public BlogMap()
        {
            Id(x => x.Id);
            Map(x => x.Title).Length(500).Not.Nullable();
            Map(x => x.Description).Length(5000).Not.Nullable();
            Map(x => x.DateCreated).Not.Nullable();
            References(x => x.User).Column("AuthorBlog").Not.Nullable();
            HasMany(x => x.Posts).Inverse().Cascade.All().KeyColumn("BlogPost");
        }
    }
}
