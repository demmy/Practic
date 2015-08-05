using Blog.Domain.Entities;
using FluentNHibernate.Mapping;

namespace Blog.Domain.Mappings
{
    class CommentsMap : ClassMap<Comment>
    {
        public CommentsMap()
        {
            Id(x => x.Id);
            Map(x => x.Description).Length(5000).Not.Nullable();
            Map(x => x.Commented).Not.Nullable();
            References(x => x.User)
                .Column("AuthorComment")
                .Not.Nullable();
            References(x => x.Post)
                .Column("PostComment")
                .Not.Nullable();
        }
    }
}
