using APIcodefirst.Models;
using APIcodefirst.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIcodefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository hr;

        public HotelController(IHotelRepository hr)
        {
            this.hr = hr;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hotels>> GetHotel()
        {
            try
            {
                return Ok(hr.GetHotel());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Hotels> Getid(int id)
        {
            try
            {
                var hotel = hr.GetHotelByid(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Hotels> Post(Hotels hotel)
        {
            try
            {
                return Ok(hr.PostHotel(hotel));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Hotels hotel)
        {
            try
            {
                hr.PutHotel(hotel);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                hr.DeleteHotel(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/filter/location")]
        public ActionResult<IEnumerable<Hotels>> GetLocation(string location)
        {
            try
            {
                return Ok(hr.GetLocation(location));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/filter/price")]
        public ActionResult<IEnumerable<Hotels>> GetPrice(int price)
        {
            try
            {
                return Ok(hr.GetPrice(price));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/filter/amenities")]
        public ActionResult<IEnumerable<Hotels>> GetAmenities(string amenities)
        {
            try
            {
                return Ok(hr.GetAmenities(amenities));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/count/rooms")]
        public ActionResult<int> GetRoomAvailabilityCount(string hotelname)
        {
            try
            {
                int availablerooms = hr.GetRoomAvailabilityCount(hotelname);
                return Ok(availablerooms);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
