using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using Blog.WebUI.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Blog.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private int countItemOnPage = 3; /* количество элементов на одной странице */

        public AccountController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        /* Выход из аккаунта*/
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AllBlogs", "Blog");
        }

        /* Возвращает id авторизованного пользователя */
        public int idAuthorizationUser()
        {
            User user = _blogRepository.ListUsers.Where(u => u.Email == HttpContext.User.Identity.Name).FirstOrDefault();
            return user.Id;
        }

        /* Возвращает представление авторизации */
        public ActionResult Login()
        {
            return View();
        }

        /* Авторизация */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = _blogRepository.ListUsers.Where(u => u.Email == loginModel.Email && u.Password == loginModel.Password).FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Email, true);
                    return RedirectToAction("AllBlogs", "Blog");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(loginModel);
        }

        /* Возвращает представление регистрации */
        public ActionResult Register()
        {
            return View();
        }

        /* Регистрация */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = _blogRepository.ListUsers.Where(u => u.Email == registerModel.Email && u.Password == registerModel.Password).FirstOrDefault();
                if (user == null)
                {
                    user = new User { Email = registerModel.Email, Password = registerModel.Password, Name = registerModel.Name };
                    _blogRepository.AddUser(user);
                    user = _blogRepository.ListUsers.Where(u => u.Email == registerModel.Email && u.Password == registerModel.Password).FirstOrDefault();
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(registerModel.Email, true);
                        return RedirectToAction("SuccessRegister", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(registerModel);
        }

        /* Возвращает представление успешной регистрации */
        public ActionResult SuccessRegister()
        {
            return View();
        }

        /* Возвращает представление создания блога */
        public ActionResult CreateBlog()
        {
            return View();
        }

        /* Создание блога */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateBlog(AddBlog addBlogModel)
        {
            if (ModelState.IsValid)
            {
                User user = _blogRepository.ListUsers.Where(u => u.Id == idAuthorizationUser()).FirstOrDefault();
                BlogModel blog = _blogRepository.ListBlogs.Where(u => u.Title == addBlogModel.Title && u.Description == addBlogModel.Description && u.User == user).FirstOrDefault();
                if (blog == null)
                {
                    blog = new BlogModel { Title = addBlogModel.Title, Description = addBlogModel.Description, User = user, DateCreated = DateTime.Now };
                    _blogRepository.AddBlog(blog);
                    blog = _blogRepository.ListBlogs.Where(u => u.Title == addBlogModel.Title && u.Description == addBlogModel.Description && u.User == user).FirstOrDefault();
                    if (blog != null)
                    {
                        return RedirectToAction("SuccessCreatedBlog", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Такой блог уже существует");
                }
            }

            return View(addBlogModel);
        }

        /* Возвращает представление успешного добавления блога */
        public ActionResult SuccessCreatedBlog()
        {
            return View();
        }

        /* Блоги пользователя */
        public ViewResult BlogsUser(int page = 1)
        {
            BlogsUserListViewModel listBlogsUser = new BlogsUserListViewModel
            {
                Blogs = _blogRepository.ListBlogs.Where(u => u.User.Id == idAuthorizationUser()).Skip((page - 1) * countItemOnPage).Take(countItemOnPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    CountItemsOnPage = countItemOnPage,
                    CountItems = _blogRepository.ListBlogs.Where(u => u.User.Id == idAuthorizationUser()).Count()
                }
            };
            return View("ListBlogs", listBlogsUser);
        }

        /* Возвращает представление добавления поста в конкретный блог */
        public ActionResult AddPost(int idBlog)
        {
            ViewBag.Id = idBlog;
            return View();
        }

        /* Добавление поста */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddPost(AddPost addPostModel)
        {
            if (ModelState.IsValid)
            {
                Post post = null;
                User user = _blogRepository.ListUsers.Where(u => u.Id == idAuthorizationUser()).FirstOrDefault();
                BlogModel blog = _blogRepository.ListBlogs.Where(u => u.Id == addPostModel.idBlog).FirstOrDefault();
                post = _blogRepository.ListPosts.Where(u => u.Title == addPostModel.Title && u.Description == addPostModel.Description && u.User == user).FirstOrDefault();
                if (post == null)
                {
                    post = new Post { Title = addPostModel.Title, ShortDescription = addPostModel.ShortDescription, Description = addPostModel.Description, Blog = blog, User = user, PostedOn = DateTime.Now };
                    _blogRepository.AddPost(post);
                    post = _blogRepository.ListPosts.Where(u => u.Title == addPostModel.Title && u.Description == addPostModel.Description && u.User == user).FirstOrDefault();
                    if (post != null)
                    {
                        return RedirectToAction("SuccessAddedPost", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Такой пост уже существует");
                }
            }

            return View(addPostModel);
        }

        /* Возвращает представление успешно добавленного поста */
        public ActionResult SuccessAddedPost()
        {
            return View();
        }

        /* Возвращает представление добавления комментария */
        public ViewResult AddComment(int idPost)
        {
            ViewBag.Id = idPost;
            return View();
        }

        /* Добавление комментария */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddComment(AddComment addCommentModel)
        {
            if (ModelState.IsValid)
            {
                User user = _blogRepository.ListUsers.Where(u => u.Id == idAuthorizationUser()).FirstOrDefault();
                Post post = _blogRepository.ListPosts.Where(u => u.Id == addCommentModel.idPost).FirstOrDefault();
                Comment comment = new Comment { Description = addCommentModel.Description, Post = post, User = user, Commented = DateTime.Now };
                _blogRepository.AddComment(comment);
                post = _blogRepository.ListPosts.Where(u => u.Id == addCommentModel.idPost).FirstOrDefault();
                return View("Post", post);
            }
            return View(addCommentModel);
        }
    }
}