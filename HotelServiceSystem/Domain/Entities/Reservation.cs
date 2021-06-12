using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Logic.Interfaces.Entities;

namespace HotelServiceSystem.Domain.Entities
{
    public class Reservation : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Client Client { get; set; }
        
        public int NumberOfGuests { get; set; }
        
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        public double Price { get; set; }
        
        public DateTime DateOfSubmission { get; set; }
        
        public double Discount { get; set; }
        
        public bool HasFinished { get; set; }
        
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }
        
        public virtual ICollection<AdditionalServiceReservation> AdditionalServiceReservations { get; set; }

        public Reservation()
        {
            RoomReservations = new HashSet<RoomReservation>();
            AdditionalServiceReservations = new HashSet<AdditionalServiceReservation>();
        }
    }
}