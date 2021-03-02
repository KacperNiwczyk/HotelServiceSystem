using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public bool IsActive { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Client()
        {
            Reservations = new HashSet<Reservation>();
        }

        public static Client Default =>
            new Client
            {
                CompanyName = "",
                Email = "",
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            };
    }
}