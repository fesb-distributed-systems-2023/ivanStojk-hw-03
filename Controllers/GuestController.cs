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
using ivanStojk_CRUD_API.Controllers.DTO;
using ivanStojk_CRUD_API.Filters;
using ivanStojk_CRUD_API.Controllers;
using ivanStojk_CRUD_API.Logic;
using static ivanStojk_CRUD_API.Filters.FilterLog;
using System;
using System.Collections.Generic;
using System.Linq;
using ivanStojk_CRUD_API.Repositories;

namespace ivanStojk_CRUD_API.Controllers
{
    [LogFilter]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestLogic _guestLogic;

        public GuestController(IGuestLogic guestLogic)
        {
            this._guestLogic = guestLogic;
        }

        
        [HttpPost("/guest/new")]
        public ActionResult CreateNewGuest([FromBody] NewGuestDTO guest )
        {
            if (guest==null)
            {
                return BadRequest("Something went wrong!");

            }
            else
            {
                var guestDTO = guest.ToModel();
                _guestLogic.CreateNewGuest(guestDTO);
                return Ok("New guest created!");
            }
        }

        
        [HttpGet("/guest/all")]
        public ActionResult <IEnumerable<AboutGuestDTO>>Get()
        {

            var allGuest = _guestLogic.GetAllGuest().Select(x => AboutGuestDTO.FromModel(x));
            return Ok(allGuest);
        }

        
        [HttpGet("/guest/{id}")]
        public ActionResult<AboutGuestDTO> Get(int id)
        {
            var guest = _guestLogic.GetSingleGuest(id);
            if (guest == null)
            {
                return NotFound($"Guest with ID {id} not found.");
            }

            return Ok(AboutGuestDTO.FromModel(guest));
        }

        
        [HttpDelete("/guest/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var guest=_guestLogic.GetSingleGuest(id);
            if(guest == null)
            {
                return NotFound($"Guest with ID {id} not found.");
            }
            _guestLogic.DeleteGuest(id);
            return Ok($"Guest with ID {id} deleted");
        }
        [HttpGet("/room/{str}")]
        public ActionResult<AboutGuestDTO>Get(string str)
        {
            var guest = _guestLogic.GetGuestByRoomNumber(str);

            if (guest is null)
            {
                return NotFound($"Guest with room number:{str} doesn't exist!");
            }
            else
            {
                return Ok(guest);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NewGuestDTO updatedGuest)
        {
            if (updatedGuest == null)
            {
                return BadRequest($"Wrong guest format!");
            }

            var existingGuest = _guestLogic.GetSingleGuest(id);
            if (existingGuest == null)
            {
                return NotFound($"Guest with id {id} not found!");
            }

            _guestLogic.UpdateGuest(id, updatedGuest.ToModel());

            return Ok();
        }

    }
}