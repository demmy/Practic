using Blog.Domain.Entities;
using FluentNHibernate.Mapping;

namespace Blog.Domain.Mappings
{
    class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id);
            Map(x => x.Title).Length(1000).Not.Nullable();
            Map(x => x.ShortDescription).Length(2000).Not.Nullable();
            Map(x => x.Description).Length(5000).Not.Nullable();
            Map(x => x.PostedOn).Not.Nullable();
            References(x => x.Blog).Column("BlogPost").Not.Nullable();
            References(x => x.User).Column("AuthorPost").Not.Nullable();
            HasMany(x => x.Comments).Inverse().Cascade.All().KeyColumn("PostComment");
        }
    }
}
