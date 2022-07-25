using System.ComponentModel.DataAnnotations;

namespace MyAPI.Dtos
{
    public class CustomerUpdateDto {
        [Required]
        public string? FirstName {get;set;}
        [Required]
        public string? LastName {get;set;}
        public string? Email{get;set;}
    }
}