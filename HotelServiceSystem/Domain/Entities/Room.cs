using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Logic.Interfaces.Entities;

namespace HotelServiceSystem.Domain.Entities
{
    public class Room : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string RoomIdentifier { get; set; }
        
        public virtual ICollection<Bed> Beds { get; }
        
        public int Floor { get; set; }
        
        public double Price { get; set; }
        
        public bool IsFreeNow { get; set; }
        
        public bool IsOutOfService { get; set; }
        
        public bool ShouldBeCleaned { get; set; }
        
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }
        
        public virtual ICollection<AdditionalServiceRoom> AdditionalServiceRooms { get; set; }

        public Room()
        {
            Beds = new HashSet<Bed>();
            RoomReservations = new HashSet<RoomReservation>();
            AdditionalServiceRooms = new HashSet<AdditionalServiceRoom>();
        }
    }
}