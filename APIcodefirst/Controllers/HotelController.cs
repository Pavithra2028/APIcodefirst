using APIcodefirst.Models;
using APIcodefirst.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public IEnumerable<Hotels> GetHotel()
        {
            return hr.GetHotel();
        }

        [HttpGet("{id}")]

        public Hotels Getid(int id)
        {
            return hr.GetHotelByid(id);
        }

        [HttpPost]

        public Hotels Post(Hotels hotel)
        {
            return hr.PostHotel(hotel);
        }

        [HttpPut("{id}")]

        public void Put(Hotels hotel)
        {
            hr.PutHotel(hotel);
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            hr.DeleteHotel(id);
        }
        [HttpGet("/filter/location")]
        public IEnumerable<Hotels> GetLocation(string location)
        {
            return hr.GetLocation(location);
        }
        [HttpGet("/filter/price")]
        public IEnumerable<Hotels> GetPrice(int price)
        {
            return hr.GetPrice(price);
        }
        [HttpGet("/filter/amenities")]
        public IEnumerable<Hotels> GetAmenities(string amenities)
        {
            return hr.GetAmenities(amenities);
        }
        [HttpGet("/count/rooms")]
        public int GetRoomAvailabilityCount(string hotelname)
        {
            int availablerooms = hr.GetRoomAvailabilityCount(hotelname);
            return availablerooms;
        }
    }
}
