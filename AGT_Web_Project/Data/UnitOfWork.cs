using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork
    {
        private Agt_Project_DBEntities _dbContext;

        //Repositoryler
        private ProductRepository _productRepository;
        private CustomerRepository _customerRepository;

        public UnitOfWork()
        {
            _dbContext = new Agt_Project_DBEntities();
        }

        // BLL Katmanında kullanılması için oluşturuldu.
        public ProductRepository ProductRepository => _productRepository ?? new ProductRepository(_dbContext);
        public CustomerRepository CustomerRepository => _customerRepository ?? new CustomerRepository(_dbContext);
    }
}
