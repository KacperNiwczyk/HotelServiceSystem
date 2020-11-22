using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Interfaces.Entities;

namespace HotelServiceSystem.Entities
{
    public class Room : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string RoomIdentifier { get; set; }
        
        public int GuestsCapacity { get; set; }
        
        public int NumberOfBeds { get; set; }
        
        public int Floor { get; set; }
        
        public double Price { get; set; }
        
        public bool IsFree { get; set; }
        
        public bool IsOutOfService { get; set; }
        
        public bool ShouldBeCleaned { get; set; }
    }
}