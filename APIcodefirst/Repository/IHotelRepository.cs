using APIcodefirst.Models;

namespace APIcodefirst.Repository
{
    public interface IHotelRepository
    {
        public IEnumerable<Hotels> GetHotel();

        public Hotels GetHotelByid(int id);

        public Hotels PostHotel(Hotels hotel);

        public void PutHotel(Hotels hotel);

        public void DeleteHotel(int id);

        int GetRoomAvailabilityCount(string hotelname);

        IEnumerable<Hotels> GetLocation(string location);


        IEnumerable<Hotels> GetPrice(int price);

        IEnumerable<Hotels> GetAmenities(string amenities);

        IEnumerable<Hotels> FilterHotels(string location, int price, string amenities);

    }
}
