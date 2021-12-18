namespace RtaAssignment.Business.Common.Contracts.V1.Dtos
{
    public class PaginationDetailsDto
    {
        public PaginationDetailsDto(int currentPage, int itemsPerPage, long totalItems, int totalPages)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public long TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}