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



    }
}
