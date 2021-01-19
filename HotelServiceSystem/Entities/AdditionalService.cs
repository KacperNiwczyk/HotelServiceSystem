using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Interfaces.Entities;

namespace HotelServiceSystem.Entities
{
    public class AdditionalService : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        

    }
}