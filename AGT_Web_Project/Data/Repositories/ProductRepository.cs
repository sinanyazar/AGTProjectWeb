using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(Agt_Project_DBEntities dbContext) : base(dbContext)
        {
        }
    }
}
