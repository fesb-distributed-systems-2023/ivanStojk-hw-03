/*
**********************************
* Author: Ivan Stojković
* Project Task: Hotel --> Phase 2
**********************************
* Description:
*  
*  Implement `IGuestRepository` interface
*
**********************************
*/

using ivanStojk_CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ivanStojk_CRUD_API.Repositories
{
    public interface IGuestRepository
    {
        bool CreateNewGuest(Guest guest);
        bool DeleteGuest(int id);
        List<Guest> GetAllGuest();
        Guest GetSingleGuest(int id);
        Guest GetGuestByRoomNumber(string str);
        bool UpdateGuest(int id, Guest updatedGuest);

    }
}