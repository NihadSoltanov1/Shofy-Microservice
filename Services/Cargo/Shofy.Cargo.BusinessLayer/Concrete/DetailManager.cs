using Shofy.Cargo.BusinessLayer.Abstract;
using Shofy.Cargo.DataAccessLayer.Abstract;
using Shofy.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.BusinessLayer.Concrete
{
    public class DetailManager : IDetailService
    {
        private readonly IDetailRepository _repository;

        public DetailManager(IDetailRepository repository)
        {
            _repository = repository;
        }

        public void TAdd(Detail entity)
        {
            _repository.Add(entity);
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public List<Detail> TGetAll()
        {
            return _repository.GetAll();
        }

        public Detail TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public void TUpdate(Detail entity)
        {
            _repository.Update(entity);
        }
    }
}
