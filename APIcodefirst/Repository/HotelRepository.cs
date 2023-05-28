using APIcodefirst.DB;
using APIcodefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace APIcodefirst.Repository
{
    public class HotelRepository:IHotelRepository
    {
        private readonly HotelContext hotelContext;

        public HotelRepository(HotelContext con)
        {
            hotelContext = con;
        }
        public Hotels GetHotelByid(int id)

        {

            return hotelContext.Hotels.FirstOrDefault(x => x.HotelId == id);
        }
        public IEnumerable<Hotels> GetHotel()
        {
            return hotelContext.Hotels
                .Include(x=>x.Rooms)
                .Include(x => x.Staff)
                .Include(x=>x.Reservations)
                .ToList();
        }
        public Hotels PostHotel(Hotels hotel)
        {
            hotelContext.Hotels.Find(hotel.HotelId);
            hotelContext.Hotels.Add(hotel);
            hotelContext.SaveChanges();
            return hotel;
        }
        public void PutHotel(Hotels hotel)
        {
            hotelContext.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            hotelContext.SaveChanges();
        }
        public void DeleteHotel(int id)
        {
            Hotels e = hotelContext.Hotels.FirstOrDefault(x => x.HotelId == id);
            hotelContext.Hotels.Remove(e);
            hotelContext.SaveChanges();
        }
        public IEnumerable<Hotels> GetLocation(string location)
        {
            return hotelContext.Hotels.Where(e => e.Location == location).ToList();
        }

        public IEnumerable<Hotels> GetPrice(int price)
        {
            return hotelContext.Hotels.Where(e => e.Price == price).ToList();
        }

        public IEnumerable<Hotels> GetAmenities(string amenities)
        {
            return hotelContext.Hotels.Where(e => e.Amenities == amenities).ToList();
        }

        public int GetRoomAvailabilityCount(string hotelname)
        {
            var hotel = hotelContext.Hotels.Include(f => f.Reservations).FirstOrDefault(f => f.HotelName == hotelname);
            if (hotel == null)
                return 0;

            int totalrooms = hotel.RoomAvailability;
            int bookedrooms = hotel.Reservations.Count();
            int availablerooms = totalrooms - bookedrooms;

            return availablerooms >= 0 ? availablerooms : 0;
        }

        public IEnumerable<Hotels> FilterHotels(string location, int price, string amenities)
        {
            var filteredHotels = hotelContext.Hotels.ToList();

            if (!string.IsNullOrEmpty(location))
            {
                filteredHotels = filteredHotels.Where(h => h.Location.ToLower() == location.ToLower()).ToList();
            }

            if (price > 0)
            {
                filteredHotels = filteredHotels.Where(h => h.Price <= price).ToList();
            }

            if (!string.IsNullOrEmpty(amenities))
            {
                var amenitiesList = amenities.Split(',').Select(a => a.Trim().ToLower()).ToList();
                filteredHotels = filteredHotels.Where(h => amenitiesList.All(a => h.Amenities.ToLower().Contains(a))).ToList();
            }

            return filteredHotels;
        }
    }
}
