﻿using APIcodefirst.Models;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Models;

namespace APIcodefirst.DB
{
    public class HotelContext:DbContext
    {
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Customers> Customers { get; set; }


        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }


        public DbSet<ClassLibrary1.Models.Reservation>? Reservation { get; set; }
    }
}
