namespace BikeComparer.Common.Enums
{
    public class Paging
    {
        public enum BtnGroupPaging
        {
            FirstPage = 1,
            PreviouPage = 2,
            CurrentPage = 3,
            NextPage = 4,
            LatestPage = 5
        }

        public enum PageSize //ToDo: Make this optional in the GUI
        {
            Small = 10,
            Standard = 20,
            Large = 40
        }
    }
}
