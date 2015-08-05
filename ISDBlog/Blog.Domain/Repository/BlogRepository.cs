using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Domain
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ISession _session;

        public BlogRepository(ISession session)
        {
            _session = session;
        }

        /* Возвращает коллекцию блогов, отсортированных по id */
        public IEnumerable<BlogModel> ListBlogs
        {
            get
            {
                return _session.Query<BlogModel>().OrderByDescending(p => p.Id).ToList();
            }
        }

        /* Возвращает коллекцию постов, отсортированных по id */
        public IEnumerable<Post> ListPosts
        {
            get
            {
                return _session.Query<Post>().OrderByDescending(p => p.Id).ToList();
            }
        }

        /* Возвращает коллекцию постов конкретного блога, отсортированных по id */
        public IEnumerable<Post> PostsBlog(BlogModel blog)
        {
            return _session.Query<Post>().Where(p => p.Blog == blog).ToList().OrderByDescending(p => p.Id);
        }

        /* Возвращает коллекцию пользователей */
        public IEnumerable<User> ListUsers
        {
            get
            {
                return _session.Query<User>().ToList();
            }
        }

        /* Добавление пользователя в БД */
        public void AddUser(User user)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(user);
                transaction.Commit();
            }
        }

        /* Добавление блога в БД */
        public void AddBlog(BlogModel blog)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(blog);
                transaction.Commit();
            }
        }

        /* Добавление поста в БД */
        public void AddPost(Post post)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(post);
                transaction.Commit();
            }
        }

        /* Добавление комментария в БД */
        public void AddComment(Comment comment)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(comment);
                transaction.Commit();
            }
        }

        /* Возвращает конкретный пост */
        public Post Post(int id)
        {
            return _session.Query<Post>().Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
