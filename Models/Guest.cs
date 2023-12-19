namespace ivanStojk_CRUD_API.Models
{
    public class Guest
    {
        public int ID { get; set; }
        public string HotelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomNumber { get; set; }
    }
}
