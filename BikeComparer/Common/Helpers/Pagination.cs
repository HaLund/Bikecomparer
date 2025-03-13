using BikeComparer.Common.Enums;
using static BikeComparer.Common.Enums.Paging;

namespace BikeComparer.Common.Helpers
{
    public class Pagination
    {
        public static int CurrentPage { get; private set; }
        public static int PreviousPage => CurrentPage == 1 ? 1 : CurrentPage - 1;
        public static int NextPage => CurrentPage == TotalPages ? TotalPages : CurrentPage + 1;
        public static int PageSize { get; private set; } = (int)Paging.PageSize.Standard;
        public static int TotalCount { get; private set; }
        public static int TotalPages => (int)Math.Ceiling((double)(TotalCount / (double)PageSize));//TotalCount % PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1;// : (int)Math.Ceiling((double)(TotalCount / (double)PageSize)) + 1;
        public static int ItemsToSkip => CurrentPage == 1 ? 0 : (CurrentPage - 1) * PageSize;

        public Pagination() { }
        public Pagination(int currentPage, int totalCount, PageSize pageSize = Paging.PageSize.Standard)
        {
            CurrentPage = currentPage;
            TotalCount = totalCount;
            PageSize = (int)pageSize;
        }

        public Pagination(int currentPage, int totalCount, PageSize pageSize = Paging.PageSize.Standard, BtnGroupPaging btnGroupPaging = BtnGroupPaging.FirstPage)
        {
            Pagination pagination = new Pagination(currentPage, totalCount, Paging.PageSize.Standard);

            switch (btnGroupPaging)
            {
                case BtnGroupPaging.FirstPage: 
                    CurrentPage = 1;
                    break;
                case BtnGroupPaging.PreviouPage: 
                    CurrentPage = PreviousPage;
                    break;
                case BtnGroupPaging.NextPage:
                    CurrentPage = NextPage;
                    break;
                case BtnGroupPaging.LatestPage:
                    CurrentPage = TotalPages;
                    break;
                default:
                    CurrentPage = 1;
                    break;
            }

        }
        public static List<int> PagesList
        {
            get
            {
                var pages = new List<int>();
                for (int i = 1; i <= TotalPages; i++)
                {
                    pages.Add(i);
                }
                return pages;
            }
        }
    }
}
