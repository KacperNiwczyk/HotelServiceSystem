using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelServiceSystem.Core;
using HotelServiceSystem.Interfaces.Entities;

namespace HotelServiceSystem.Entities
{
    public class Room : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string RoomIdentifier { get; set; }
        
        public virtual ICollection<Bed> Beds { get; }
        
        public int Floor { get; set; }
        
        public double Price { get; set; }
        
        public bool IsFree { get; set; }
        
        public bool IsOutOfService { get; set; }
        
        public bool ShouldBeCleaned { get; set; }
        
        public virtual ICollection<RoomReservation> RoomReservations { get; }

        public Room()
        {
            Beds = new HashSet<Bed>();
            RoomReservations = new HashSet<RoomReservation>();
        }
        
    }
}