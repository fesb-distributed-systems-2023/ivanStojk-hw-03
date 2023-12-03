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
    public class GuestRepository
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
        public IEnumerable<Guest> GetAllGuest()
        {
            // Returns entire list 
            return m_lstGuest;
        }

        // READ : Get single guest (specified by ID)
        public Guest GetSingleGuest(int id)
        {
            if (!m_lstGuest.Any(guest => guest.Id == id))
            {
                // Checks if any guest matches currently used id, if not returns null
                return null;
            }

            var guest = m_lstGuest.FirstOrDefault(guest => guest.Id == id);

            // Checks if guest matches an id, if yes returns that guest
            return guest;
        }

        // DELETE : Delete guest (specified by ID)
        public bool DeleteGuest(int id)
        {
            // Check if guest matches ID
            var guestToDelete = m_lstGuest.FirstOrDefault(itemGuest => itemGuest.Id == id);
            if (guestToDelete == null)
            {
                return false;
            }

            m_lstGuest.Remove(guestToDelete);

            return true;
        }
    }
}