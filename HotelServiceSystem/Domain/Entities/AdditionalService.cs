using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Logic.Interfaces.Entities;

namespace HotelServiceSystem.Domain.Entities
{
    public class AdditionalService : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        
        public ServiceType ServiceType { get; set; }
        
        public virtual ICollection<AdditionalServiceReservation> AdditionalServiceReservations { get; set; }
        public virtual ICollection<AdditionalServiceRoom> AdditionalServiceRooms { get; set; }
        
        public AdditionalService()
        {
            AdditionalServiceReservations = new HashSet<AdditionalServiceReservation>();
            AdditionalServiceRooms = new HashSet<AdditionalServiceRoom>();
        }
        
    }
}