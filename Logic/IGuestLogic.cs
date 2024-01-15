using ivanStojk_CRUD_API.Models;


namespace ivanStojk_CRUD_API.Logic
{
    public interface IGuestLogic
    {
        void CreateNewGuest(Guest? guest);
        void UpdateGuest(int id, Guest? guest);
        Guest? GetSingleGuest(int id);
        IEnumerable<Guest> GetAllGuest();
        Guest? GetGuestByRoomNumber(string roomNumber);
        bool DeleteGuest(int id);

    }
}
