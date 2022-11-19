namespace MicroService.Template.Transversal.Common
{
    public class ResponsePagination<T>:ResponseGeneric<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get => PageNumber > 1; }
        public bool HasNextPage { get => PageNumber < TotalPages; }
    }
}
