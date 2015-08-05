using System;

namespace Blog.WebUI.Models
{
    public class PagingInfo
    {
        public int CountItems { get; set; } /* количество элементов */
        public int CountItemsOnPage { get; set; } /* количество элементов на одной странице */
        public int CurrentPage { get; set; } /* текущая страница */
        public int TotalPages /* всего страниц */
        {
            get
            {
                return (int)Math.Ceiling((decimal)CountItems / CountItemsOnPage);
            }
        }
    }
}