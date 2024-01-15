using ivanStojk_CRUD_API.Logic;
using Microsoft.Extensions.Options;
using ivanStojk_CRUD_API.Configuration;
using ivanStojk_CRUD_API.Exceptions;
using ivanStojk_CRUD_API.Models;
using System.Text.RegularExpressions;
using ivanStojk_CRUD_API.Repositories;




namespace ivanStojk_CRUD_API.Logic
{
    public class GuestLogic : IGuestLogic

    {
        private readonly IGuestRepository _guestRepository;
        private readonly ValidationConfiguration _validationConfiguration;
        public GuestLogic(IGuestRepository guestRepository, IOptions<ValidationConfiguration> configuration)
        {
             _guestRepository = guestRepository;
            _validationConfiguration = configuration.Value;
        }
        private void HotelValidation(string? hotelId)
        {
            if (hotelId is null)
            {
                throw new UserErrorException("HotelId field cannot be empty.");
            }

            if (!Regex.IsMatch(hotelId, _validationConfiguration.HotelRegex))
            {
                throw new UserErrorException($"HotelId format invalid for sender '{hotelId}'");
            }

            if (hotelId.Length > _validationConfiguration.HotelIdMaxCharacters)
            {
                throw new UserErrorException($"HotelId field too long. Exceeded {_validationConfiguration.HotelIdMaxCharacters} characters");
            }
        }
        private void FirstNameValidation(string? firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new UserErrorException("First name field cannot be empty.");
            }

            if (firstName.Length > _validationConfiguration.FirstNameMaxCharacters)
            {
                throw new UserErrorException($"First name field too long. Exceeded {_validationConfiguration.FirstNameMaxCharacters} characters");
            }

        }
        private void LastNameValidation(string? lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new UserErrorException("Last name field cannot be empty.");
            }

            if (lastName.Length > _validationConfiguration.LastNameMaxCharacters)
            {
                throw new UserErrorException($"Last name field too long. Exceeded {_validationConfiguration.LastNameMaxCharacters} characters");
            }

        }
        private void RoomNumberValidation(string? roomNumber)
        {
            if (roomNumber is not null && roomNumber.Length > _validationConfiguration.RoomNumberMaxCharacters)
            {
                throw new UserErrorException($"Room number field too long. Exceeded {_validationConfiguration.RoomNumberMaxCharacters} characters");
            }
            //ubscit logiku za roomnumber
            bool succes=int.TryParse(roomNumber, out int roomNumberInt);
            if(!succes || roomNumberInt>=_validationConfiguration.RoomNumberMaxValue)  
            {
                throw new UserErrorException($"Too big room number, max room number is {_validationConfiguration.RoomNumberMaxValue}.");
            }
        }
        public void CreateNewGuest(Guest? guest)
        {
            // Check all arguments
            if (guest is null)
            {
                throw new UserErrorException("Cannot create a new guest. No guest specified or the guest is invalid.");
            }

            // Sanitize inputs
            guest.ID = -1;

            
           

            HotelValidation(guest.HotelId);
            FirstNameValidation(guest.FirstName);
            LastNameValidation(guest.LastName);
            RoomNumberValidation(guest.RoomNumber);

            // All fields validated, continue...

            // Set email timestamp to current time
            // (use UTC for cross-timezone compatibility)
            guest.Timestamp = DateTime.UtcNow;

            _guestRepository.CreateNewGuest(guest);
        }

        public void UpdateGuest(int id, Guest? guest)
        {
            // Check all arguments
            if (guest is null)
            {
                throw new UserErrorException("Cannot create a new guest. No guest specified or the guest is invalid.");
            }

            // Sanitize inputs
            guest.ID = -1;

          

            HotelValidation(guest.HotelId);
            FirstNameValidation(guest.FirstName);
            LastNameValidation(guest.LastName);
            RoomNumberValidation(guest.RoomNumber);

            // All fields validated, continue...

            _guestRepository.UpdateGuest(id, guest);
        }

        public bool DeleteGuest(int id)
        {
            if (_guestRepository.GetSingleGuest(id) is null)
            {
                throw new UserErrorException($"Unable to find the requested guest with id {id} to be deleted.");
                return false;
            }
            else
            {
                _guestRepository.DeleteGuest(id);
                return true;
            }
        }

        public Guest? GetSingleGuest(int id)
        {
            return _guestRepository.GetSingleGuest(id);
        }

        public IEnumerable<Guest> GetAllGuest()
        {
            return _guestRepository.GetAllGuest();
        }
        public Guest GetGuestByRoomNumber(string roomNumber)
        {
            return _guestRepository.GetGuestByRoomNumber(roomNumber);
        }


    }
}
