/*
 * 
 * 
*/



using ivanStojk_CRUD_API.Models;

namespace ivanStojk_CRUD_API.Controllers.DTO
{
    
        public class NewGuestDTO
        {
            public string? HotelId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? RoomNumber { get; set; }

            public Guest ToModel()
            {
                return new Guest
                {
                    ID = -1,
                    HotelId = HotelId,
                    FirstName = FirstName,
                    LastName = LastName,
                    RoomNumber = RoomNumber,
                    Timestamp = DateTime.MinValue
                };
            }
        }
    
}

