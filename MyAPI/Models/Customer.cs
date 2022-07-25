using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class Customer {
        [Key]
        public int ID { get; set;}
        [Required]
        public string? FirstName {get;set;}
        [Required]
        public string? LastName {get;set;}
        
        public string? Email {get;set;}

    }
}