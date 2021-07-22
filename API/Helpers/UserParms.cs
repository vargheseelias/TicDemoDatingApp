namespace API.Helpers
{
    public class UserParms
    {
        private const int MaxPageSize = 50;
        public int pageNumber { get; set; } = 1;
        private int _PageSize = 10;
        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string CurrentUsername { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 150;
        public string OrderBy { get; set; }="lastActive";
    }
}