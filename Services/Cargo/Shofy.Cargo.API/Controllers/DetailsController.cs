using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shofy.Cargo.BusinessLayer.Abstract;
using Shofy.Cargo.DtoLayer.Dtos.DetailDtos;
using Shofy.Cargo.EntityLayer.Entities;

namespace Shofy.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailService _service;

        public DetailsController(IDetailService service)
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
        public IActionResult AddOperation(CreateDetailDto createDetailDto)
        {
            Detail value = new Detail()
            {
               Barcode = createDetailDto.Barcode,
               CompanyId=createDetailDto.CompanyId,
               ReceiverCustomer=createDetailDto.ReceiverCustomer,
               SenderCustomer=createDetailDto.SenderCustomer
            };
            _service.TAdd(value);
            return Ok("Details added successfully");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Detail delete successfully");
        }
        [HttpPut]
        public IActionResult Update(UpdateDetailDto updateDetailDto)
        {
            Detail value = new Detail()
            {
                Id = updateDetailDto.Id,
                Barcode = updateDetailDto.Barcode,
                CompanyId = updateDetailDto.CompanyId,
                ReceiverCustomer = updateDetailDto.ReceiverCustomer,
                SenderCustomer = updateDetailDto.SenderCustomer
            };
            _service.TUpdate(value);
            return Ok("Details modified successfully");
        }
    }
}
