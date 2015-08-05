using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using Blog.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private int countItemOnPage = 3; // количество элементов на странице

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        /* Все блоги */
        public ViewResult AllBlogs(int page = 1)
        {
            BlogListViewModel listBlogModel = new BlogListViewModel
            {
                Blogs = _blogRepository.ListBlogs.Skip((page - 1) * countItemOnPage).Take(countItemOnPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    CountItemsOnPage = countItemOnPage,
                    CountItems = _blogRepository.ListBlogs.Count()
                }
            };
            return View("ListBlogs", listBlogModel);
        }

        /* Посты блога */
        public ViewResult Posts(int id, int page = 1)
        {
            BlogModel blog = _blogRepository.ListBlogs.Where(b => b.Id == id).FirstOrDefault();
            PostListViewModel listPostModel = new PostListViewModel
            {
                Posts = _blogRepository.PostsBlog(blog).Skip((page - 1) * countItemOnPage).Take(countItemOnPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    CountItemsOnPage = countItemOnPage,
                    CountItems = _blogRepository.PostsBlog(blog).Count()
                }
            };
            return View(listPostModel);
        }

        /* Конкретный пост */
        public ActionResult Post(int idPost)
        {
            Post post = _blogRepository.Post(idPost);
            return View(post);
        }
    }
}