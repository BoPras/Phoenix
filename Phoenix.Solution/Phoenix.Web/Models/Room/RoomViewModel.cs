namespace Phoenix.Web.Models.Room
{
    public class RoomViewModel
    {
        public string? Number { get; set; }
        public int? Floor { get; set; }
        public string? Room_type { get; set; }
        public int? Guest_Limit { get; set; }
        public string? Description { get; set; }
        public decimal? Cost { get; set; }
    }
}
