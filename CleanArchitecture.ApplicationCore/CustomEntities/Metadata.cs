namespace CleanArchitecture.ApplicationCore.CustomEntities
{
    public class Metadata
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public Metadata(int totalCount, int pageSize, int currentPage, int totalPages, bool hasNextPage, bool hasPreviousPage)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
        }
    }
}
