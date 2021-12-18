using System;
using System.Collections.Generic;

namespace RtaAssignment.Business.Common.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList()
        {
        }

        public PagedList(IEnumerable<T> items, uint totalItems, int currentPage, int itemPerPage)
        {
            TotalItems = totalItems;
            ItemsPerPage = itemPerPage;
            CurrentPage = currentPage;
            TotalPages = (int) Math.Ceiling(totalItems / (double) itemPerPage);
            AddRange(items);
        }

        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int ItemsPerPage { get; }
        public uint TotalItems { get; }

        public static PagedList<T> CreateAsync(IEnumerable<T> items, uint totalItems, int currentPage, int itemPerPage)
        {
            return new PagedList<T>(items, totalItems, currentPage, itemPerPage);
        }
    }
}