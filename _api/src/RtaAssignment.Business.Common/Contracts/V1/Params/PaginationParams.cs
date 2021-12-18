namespace RtaAssignment.Business.Common.Contracts.V1.Params
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        private int _itemsPerPage;

        public int CurrentPage { get; set; }

        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set => _itemsPerPage = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}