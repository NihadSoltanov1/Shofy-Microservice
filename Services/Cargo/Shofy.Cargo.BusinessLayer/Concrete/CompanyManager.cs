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
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyManager(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public void TAdd(Company entity)
        {
            _repository.Add(entity);
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public List<Company> TGetAll()
        {
            return _repository.GetAll();
        }

        public Company TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public void TUpdate(Company entity)
        {
            _repository.Update(entity);
        }
    }
}
