using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLayer.Services
{
    interface IEntityService<TEntity>
    {
        List<TEntity> GetList();
        TEntity GetById(int entityId);
    }
}
