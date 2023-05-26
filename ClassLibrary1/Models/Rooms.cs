using System.ComponentModel.DataAnnotations;

namespace APIcodefirst.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public string Room_Name { get; set; }

        public Hotels Hotels { get; set; }

    }
}
