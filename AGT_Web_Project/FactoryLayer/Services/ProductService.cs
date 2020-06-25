using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace FactoryLayer.Services
{
    public class ProductService : IEntityService<Product>
    {
        private UnitOfWork _uof;

        public ProductService()
        {
            _uof = SingletonUnitOfWork.UOW;
        }

        public List<Product> GetList()
        {
            return _uof.ProductRepository.GetAll();
        }

        public Product GetById(int entityId)
        {
            return _uof.ProductRepository.List(entityId);
        }
    }
}
