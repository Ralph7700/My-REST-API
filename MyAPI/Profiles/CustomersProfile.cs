using AutoMapper;
using MyAPI.Models;
using MyAPI.Dtos;

namespace MyAPI.Profiles{
    public class CustomersProfile : Profile{
        
        public CustomersProfile(){
            CreateMap<Customer,CustomerReadDto>();
            CreateMap<CustomerCreateDto,Customer>();
            CreateMap<CustomerUpdateDto,Customer>();
            CreateMap<Customer,CustomerUpdateDto>();
        }
    }
}