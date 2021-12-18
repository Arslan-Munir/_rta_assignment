namespace RtaAssignment.Business.Common.Contracts.V1.Params
{
    public class EmployeeParams : PaginationParams
    {
        private string _toSearch;

        public string ToSearch
        {
            get => _toSearch;
            set => _toSearch = value.Trim().ToLower();
        }

        public EmployeeParams()
        {
            CurrentPage = 1;
            ItemsPerPage = 10;
        }
    }
}