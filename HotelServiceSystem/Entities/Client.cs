using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Interfaces.Entities;

namespace HotelServiceSystem.Entities
{
    public class Client : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string CompanyName { get; set; }

        public string TaxId { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
    }
}