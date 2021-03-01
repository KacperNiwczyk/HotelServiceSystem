using System;
using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Features.Enums;
using HotelServiceSystem.Interfaces.Entities;

namespace HotelServiceSystem.Entities
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public UserRole UserRole { get; set; }
        
        public DateTime DateOfRegistration { get; set; }
        
        public DateTime LastLogin { get; set; }
        
        public bool IsActive { get; set; }
    }
}