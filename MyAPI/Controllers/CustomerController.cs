using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Data;
using MyAPI.Dtos;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]

    public class CustomerController:Controller{

        public readonly ICustomerRepo _repository;
        public readonly IMapper _mapper;
        public CustomerController(ICustomerRepo repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllcustomers(){
            var customersItem = _repository.GetAllCustomers();
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customersItem));
        }

        [HttpGet("{id}",Name ="GetCustomerByid")]
        public ActionResult<CustomerReadDto> GetCustomerByid(int id){

            var customerItem = _repository.GetCustomerById(id);

            if(customerItem==null)return NotFound();
               
            return Ok(_mapper.Map<CustomerReadDto>(customerItem));
            
        }
        
        [HttpPost]
        public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto newCustomerDto){
            
            var customerModel = _mapper.Map<Customer>(newCustomerDto);
            _repository.CreateCustomer(customerModel);
            _repository.SaveChages();
            var custReadDto = _mapper.Map<CustomerReadDto>(customerModel);
            return CreatedAtRoute(nameof(GetCustomerByid),new {Id = custReadDto.ID}, custReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto){
            var customerModelFromRepo = _repository.GetCustomerById(id);
            if(customerModelFromRepo == null){
                return NotFound();
            }
            
            _mapper.Map(customerUpdateDto, customerModelFromRepo);

            _repository.UpdateCustomer(customerModelFromRepo);

            _repository.SaveChages();

            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult CustomerEdit(int id, JsonPatchDocument<CustomerUpdateDto> patchDocument)
        {
            var customerModelFromRepo = _repository.GetCustomerById(id);
            if(customerModelFromRepo == null){
                return NotFound();
            }
            var customertoPatch = _mapper.Map<CustomerUpdateDto>(customerModelFromRepo);
            patchDocument.ApplyTo(customertoPatch,ModelState);
            if(!TryValidateModel(customertoPatch)){
                return ValidationProblem(ModelState);
            }
            _mapper.Map(customertoPatch, customerModelFromRepo);

            _repository.UpdateCustomer(customerModelFromRepo);

            _repository.SaveChages();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<CustomerReadDto> DeleteCustomer(int id){
            var customerModelFromRepo = _repository.GetCustomerById(id);
            if(customerModelFromRepo == null){
                return NotFound();
            }
            _repository.DeleteCustomer(customerModelFromRepo);
            _repository.SaveChages();
            return Ok(_mapper.Map<CustomerReadDto>(customerModelFromRepo));
        }
    }
}