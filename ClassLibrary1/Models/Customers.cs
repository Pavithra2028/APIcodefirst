using ClassLibrary1.Models;
using System.ComponentModel.DataAnnotations;

namespace APIcodefirst.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public string? CustomerPassword { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
