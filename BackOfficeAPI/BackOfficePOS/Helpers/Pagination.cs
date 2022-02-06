namespace BackOfficePOS.Helpers
{
    public class Pagination <T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> records)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Records = records;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Records { get; set; }
    }
}
