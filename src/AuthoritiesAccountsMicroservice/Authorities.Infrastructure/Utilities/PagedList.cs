﻿using Microsoft.EntityFrameworkCore;

namespace Authorities.Infrastructure.Utilities
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItemsCount { get; private set; }

        public bool HasPreviousPage => CurrentPage > 1 ? true : false;

        public bool HasNextPage => CurrentPage < TotalPages ? true : false;

        private PagedList(IEnumerable<T> items, int itemsCount, int pageNumber, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(itemsCount / (double)pageSize);
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalItemsCount = itemsCount;

            AddRange(items);
        }

        /// <summary>
        /// Used to form a pagedList from provided query and page parameters.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var itemsCount = query.Count();
            var items = await (query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync());

            return new PagedList<T>(items, itemsCount, pageNumber, pageSize);
        }
    }
}