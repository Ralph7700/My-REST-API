using System.ComponentModel.DataAnnotations;

namespace MyAPI.Dtos
{
    public class CustomerCreateDto {
        public string? FirstName {get;set;}
        public string? LastName {get;set;}
        public string? Email{get;set;}
    }
}