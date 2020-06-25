using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace FactoryLayer.Services
{
    public class CustomerService : IEntityService<Customer>
    {
        private UnitOfWork _uof;

        public CustomerService()
        {
            _uof = SingletonUnitOfWork.UOW;
        }

        public Customer GetById(int entityId)
        {
            return _uof.CustomerRepository.List(entityId);
        }

        public List<Customer> GetList()
        {
            return _uof.CustomerRepository.GetAll();
        }
    }
}
