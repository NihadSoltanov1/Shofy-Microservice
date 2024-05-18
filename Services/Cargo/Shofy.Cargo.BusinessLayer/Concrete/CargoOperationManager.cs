using AutoMapper;
using Shofy.Cargo.BusinessLayer.Abstract;
using Shofy.Cargo.DataAccessLayer.Abstract;
using Shofy.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using Shofy.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationRepository _repository;

        public CargoOperationManager(ICargoOperationRepository repository)
        {
            _repository = repository;
        }

        public void TAdd(CargoOperation entity)
        {
            _repository.Add(entity);
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _repository.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public void TUpdate(CargoOperation entity)
        {
            _repository.Update(entity);
        }
    }
}
