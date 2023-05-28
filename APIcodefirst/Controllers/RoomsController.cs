using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIcodefirst.DB;
using APIcodefirst.Models;
using APIcodefirst.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace APIcodefirst.Controllers
{
    [Authorize(Roles = "Staff")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository hr;

        public RoomsController(IRoomRepository hr)
        {
            this.hr = hr;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rooms>> GetRoom()
        {
            try
            {
                return Ok(hr.GetRoom());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Rooms> GetRoomByid(int id)
        {
            try
            {
                var rooms = hr.GetRoomByid(id);
                if (rooms == null)
                {
                    return NotFound();
                }
                return Ok(rooms);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Rooms> Post(Rooms room)
        {
            try
            {
                return Ok(hr.PostRoom(room));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Rooms room)
        {
            try
            {
                hr.PutRoom(room);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                hr.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
