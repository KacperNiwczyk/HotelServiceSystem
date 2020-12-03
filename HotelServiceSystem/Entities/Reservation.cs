using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Interfaces.Entities;

namespace HotelServiceSystem.Entities
{
    public class Reservation : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Client Client { get; set; }
        
        public int NumberOfGuests { get; set; }
        
        public double Price { get; set; }
        
        public DateTime DateOfSubmission { get; set; }
        
        public double Discount { get; set; }
        
        public ICollection<AdditionalServiceReservation> AdditionalServiceReservations { get; set; }
    }
}