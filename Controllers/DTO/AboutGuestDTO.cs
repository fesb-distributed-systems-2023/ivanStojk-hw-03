/*
 * 
*/ 


using ivanStojk_CRUD_API.Models;

namespace ivanStojk_CRUD_API.Controllers.DTO
{
    public class AboutGuestDTO
    {
        public int ID { get; set; }
        public string HotelId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RoomNumber { get; set; }
        public string? Timestamp { get; set; }

        public static AboutGuestDTO FromModel(Guest guest)
        {
            return new AboutGuestDTO
            {
                ID = guest.ID,
                HotelId = guest.HotelId,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                RoomNumber = guest.RoomNumber,
                Timestamp = guest.Timestamp.ToLongTimeString()
            };
        }
    }
}

