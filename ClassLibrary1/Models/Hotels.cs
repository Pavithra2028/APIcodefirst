using ClassLibrary1.Models;
using System.ComponentModel.DataAnnotations;

namespace APIcodefirst.Models
{
    public class Hotels
    {
        [Key]
        public int HotelId { get; set; }

        public string? HotelName { get; set; }


        public string Location { get; set; }
        public int? Price { get; set; }
        public int RoomAvailability { get; set; }

        public string Amenities { get; set; }

        public ICollection<Rooms>? Rooms { get; set; }
        public ICollection<Staff>? Staff { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }

    }
}
