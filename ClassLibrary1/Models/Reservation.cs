using APIcodefirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class Reservation
    {
        [Key]
        public int Reservation_id { get; set; }
        public DateTime Check_in_date { get; set; }
        public DateTime Check_out_date { get; set; }

        
        public Customers? Customers { get; set; }
        public Hotels? hotels { get; set; }
    }
}
