﻿using System.ComponentModel.DataAnnotations;

namespace APIcodefirst.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public Hotels? Hotels { get; set; }
    }
}
