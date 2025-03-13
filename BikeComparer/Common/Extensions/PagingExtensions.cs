using static BikeComparer.Common.Enums.Paging;

namespace BikeComparer.Common.Extensions
{
    public static class PagingExtensions
    {
        public static BtnGroupPaging GetBtnGroupPagingValue(this string btnGroupPaging)
        {
            BtnGroupPaging _btnGroupPaging;

            switch (btnGroupPaging)
            {
                case "FirstPage":
                    _btnGroupPaging = BtnGroupPaging.FirstPage;
                    break;
                case "PreviousPage":
                    _btnGroupPaging = BtnGroupPaging.PreviouPage;
                    break;
                case "NextPage":
                    _btnGroupPaging = BtnGroupPaging.NextPage;
                    break;
                case "LastPage":
                    _btnGroupPaging = BtnGroupPaging.LatestPage;
                    break;
                default:
                    _btnGroupPaging = BtnGroupPaging.FirstPage;
                    break;
            }
            return _btnGroupPaging;
        }
    }
}
