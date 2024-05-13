﻿using System.Collections;

namespace MoviesWebApi.Pagination
{
    public class PagedList<T> : IReadOnlyList<T>
    {
        private readonly IList<T> subset;
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            subset = items as IList<T> ?? new List<T>(items);
        }

        public int PageNumber { get; }

        public int TotalPages { get; }

        public bool IsFirstPage => PageNumber == 1;

        public bool IsLastPage => PageNumber == TotalPages;

        public int Count => subset.Count;

        public T this[int index] => subset[index];

        public IEnumerator<T> GetEnumerator() => subset.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => subset.GetEnumerator();
    }
}
