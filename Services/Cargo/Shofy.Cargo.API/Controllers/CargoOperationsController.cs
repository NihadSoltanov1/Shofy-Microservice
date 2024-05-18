using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shofy.Cargo.BusinessLayer.Abstract;
using Shofy.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using Shofy.Cargo.EntityLayer.Entities;

namespace Shofy.Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _service;

        public CargoOperationsController(ICargoOperationService service)
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
        public IActionResult AddOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation value = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };
            _service.TAdd(value);
            return Ok("Cargo Operation added successfully");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Cargo Operation delete successfully");
        }
        [HttpPut]
        public IActionResult Update(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation value = new CargoOperation()
            {
                Id = updateCargoOperationDto.Id,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _service.TUpdate(value);
            return Ok("Cargo Operation modified successfully");
        }
    }
}
