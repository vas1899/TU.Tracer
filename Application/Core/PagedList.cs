using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int currentPage, int pageSize, int itemsCount)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(itemsCount / (double)pageSize);
            PageSize = pageSize;
            ItemsCount = itemsCount;
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int ItemsCount { get; set; }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int currentPage, int pageSize)
        {
            int itemsCount = await source.CountAsync();
            var items = await source.Skip(pageSize * (currentPage-1)).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, currentPage, pageSize, itemsCount);
        }

    }
}
