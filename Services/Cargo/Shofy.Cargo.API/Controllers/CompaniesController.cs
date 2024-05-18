using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shofy.Cargo.BusinessLayer.Abstract;
using Shofy.Cargo.DtoLayer.Dtos.CompanyDtos;
using Shofy.Cargo.EntityLayer.Entities;

namespace Shofy.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
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
        public IActionResult AddOperation(CreateCompanyDto createCompanyDto)
        {
            Company value = new Company()
            {
               Name=createCompanyDto.Name
            };
            _service.TAdd(value);
            return Ok("Company added successfully");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Comapany delete successfully");
        }
        [HttpPut]
        public IActionResult Update(UpdateCompanyDto updateCompanyDto)
        {
            Company value = new Company()
            {
                Id = updateCompanyDto.Id,
                Name=updateCompanyDto.Name
            };
            _service.TUpdate(value);
            return Ok("Company modified successfully");
        }
    }
}
