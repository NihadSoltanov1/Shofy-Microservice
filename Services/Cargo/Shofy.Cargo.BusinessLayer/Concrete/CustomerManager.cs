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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerManager(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void TAdd(Customer entity)
        {
            _repository.Add(entity);
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public List<Customer> TGetAll()
        {
            return _repository.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public void TUpdate(Customer entity)
        {
            _repository.Update(entity);
        }
    }
}
