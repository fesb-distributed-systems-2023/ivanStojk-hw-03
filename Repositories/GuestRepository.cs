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

using Microsoft.AspNetCore.Mvc;
using ivanStojk_CRUD_API.Models;
using ivanStojk_CRUD_API.Repositories;

namespace ivanStojk_CRUD_API.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        // List of all guests
        private List<Guest> m_lstGuest;

        public GuestRepository()
        {
            // Creating new list
            m_lstGuest = new List<Guest>();
        }

        // CREATE : Create new guest
        public bool CreateNewGuest(Guest guest)
        {
            // Adding new guest to the list
            m_lstGuest.Add(guest);

            return true;
        }

        // READ : Get all guest
        public List<Guest> GetAllGuest()
        {
            // Returns entire list 
            return m_lstGuest;
        }

        // READ : Get single guest (specified by ID)
        public Guest GetSingleGuest(int id)
        {
            if (!m_lstGuest.Any(guest => guest.ID == id))
            {
                // Checks if any guest matches currently used id, if not returns null
                return null;
            }

            var guest = m_lstGuest.FirstOrDefault(guest => guest.ID == id);

            // Checks if guest matches an id, if yes returns that guest
            return guest;
        }

        // DELETE : Delete guest (specified by ID)
        public bool DeleteGuest(int id)
        {
            // Check if guest matches ID
            var guestToDelete = m_lstGuest.FirstOrDefault(itemGuest => itemGuest.ID == id);
            if (guestToDelete == null)
            {
                return false;
            }

            m_lstGuest.Remove(guestToDelete);

            return true;
        }
        public Guest GetGuestByRoomNumber(int str)
        {
            if (!m_lstGuest.Any(guest => guest.RoomNumber == str))
            {
                // Checks if any guest matches currently used id, if not returns null
                return null;
            }

            var guest = m_lstGuest.FirstOrDefault(guest => guest.RoomNumber == str);

            // Checks if guest matches an id, if yes returns that guest
            return guest;

        }
        public bool UpdateGuest(int id, Guest updatedGuest)
        {

            Guest? existingGuest = GetSingleGuest(id);
            if (existingGuest is not null)
            {
                // Update only if the user has permission
                // Implement access control logic as needed
                existingGuest.HotelId = updatedGuest.HotelId;
                existingGuest.FirstName = updatedGuest.FirstName;
                existingGuest.LastName = updatedGuest.LastName;
                existingGuest.RoomNumber = updatedGuest.RoomNumber;
            }
            else
            {
                throw new KeyNotFoundException($"Guest with ID '{id}' not found.");
            }
            return true;
        }
    }
}