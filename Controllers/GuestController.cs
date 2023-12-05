/*
**********************************
* Author: Ivan Stojković
* Project Task: Hotel-->Phase2
**********************************
* Description:
* 
*    CREATE - Add new guest
*    READ - Get all guest
*    READ - Get specific guest
*    DELETE - Delete guest
*
**********************************
*/
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ivanStojk_CRUD_API.Models;
using ivanStojk_CRUD_API.Repositories;


namespace ivanStojk_CRUD_API.Controllers
{
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly GuestRepository _guestRepository;

        public GuestController(GuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        
        [HttpPost("/guest/new")]
        public IActionResult CreateNewGuest([FromBody] Guest guest )
        {
            bool fSuccess = _guestRepository.CreateNewGuest(guest);

            if (fSuccess)
            {
                return Ok("New guest created!");
            }
            else
            {
                return BadRequest("Something went wrong!");
            }
        }

        
        [HttpGet("/guest/all")]
        public IActionResult GetAllGuest()
        {
            return Ok(_guestRepository.GetAllGuest());
        }

        
        [HttpGet("/guest/{id}")]
        public IActionResult GetSingleGuest([FromRoute] int id)
        {
            var guest = _guestRepository.GetSingleGuest(id);

            if (guest is null)
            {
                return NotFound($"Guest with id:{id} doesn't exist!");
            }
            else
            {
                return Ok(guest);
            }
        }

        
        [HttpDelete("/guest/{id}")]
        public IActionResult DeleteGuest([FromRoute] int id)
        {
            if (_guestRepository.DeleteGuest(id))
            {
                return Ok($"Deleted guest with id={id}!");
            }
            else
            {
                return NotFound($"Could not find guest with id={id}!");
            }
        }
    }
}