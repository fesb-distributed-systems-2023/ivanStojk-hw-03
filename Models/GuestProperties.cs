namespace ivanStojk_CRUD_API.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string HotelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoomNumber { get; set; }
    }
}
