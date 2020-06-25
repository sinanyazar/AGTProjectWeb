using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    interface IRepository<TEntity>
    {
        List<TEntity> GetAll(); // Tüm ürünleri ve müşterileri listeleyeceğim metodum.
        TEntity List(int id);   // Detay sayfalarında kullanacağım, id'ye göre listeleme metodum.
    }
}
