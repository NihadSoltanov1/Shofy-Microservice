using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shofy.Cargo.BusinessLayer.Abstract;
using Shofy.Cargo.DtoLayer.Dtos.CustomerDtos;
using Shofy.Cargo.EntityLayer.Entities;

namespace Shofy.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllOperations()
        {
            return Ok(_service.TGetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdOperation(int id)
        {
            return Ok(_service.TGetById(id));
        }
        [HttpPost]
        public IActionResult AddOperation(CreateCustomerDto createCustomerDto)
        {
            Customer value = new Customer()
            {
               Address=createCustomerDto.Address,
               City=createCustomerDto.City,
               District=createCustomerDto.District,
               Email=createCustomerDto.Email,
               Name=createCustomerDto.Name,
               Phone=createCustomerDto.Phone,
               Surname=createCustomerDto.Surname
            };
            _service.TAdd(value);
            return Ok("Customer added successfully");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Customer delete successfully");
        }
        [HttpPut]
        public IActionResult Update(UpdateCustomerDto updateCustomerDto)
        {
            Customer value = new Customer()
            {
                Address = updateCustomerDto.Address,
                City = updateCustomerDto.City,
                District = updateCustomerDto.District,
                Email = updateCustomerDto.Email,
                Name = updateCustomerDto.Name,
                Phone = updateCustomerDto.Phone,
                Surname = updateCustomerDto.Surname,
                Id = updateCustomerDto.Id
            };
            _service.TUpdate(value);
            return Ok("Customer modified successfully");
        }
    }
}
