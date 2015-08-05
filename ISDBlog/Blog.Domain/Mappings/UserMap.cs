using Blog.Domain.Entities;
using FluentNHibernate.Mapping;

namespace Blog.Domain.Mappings
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(100).Not.Nullable();
            Map(x => x.Email).Length(100).Not.Nullable();
            Map(x => x.Password).Length(100).Not.Nullable();
            HasMany(x => x.Blogs).Inverse().Cascade.All().KeyColumn("AuthorBlog");
            HasMany(x => x.Posts).Inverse().Cascade.All().KeyColumn("AuthorPost");
            HasMany(x => x.Comments).Inverse().Cascade.All().KeyColumn("AuthorComment");
        }
    }
}