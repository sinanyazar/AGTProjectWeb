using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace FactoryLayer
{
    class SingletonUnitOfWork
    {
        private static UnitOfWork _uof;

        private SingletonUnitOfWork() // New ile instance üretilmemesi için constructor metod private yapıldı.
        {

        }

        // Property ile instance üretilmesi ...
        public static UnitOfWork UOW
        {
            get
            {
                if (_uof == null)
                {
                    _uof = new UnitOfWork(); 
                }
                return _uof; // Instance önceden hiç üretilmemiş ise yenisini üret, üretilmiş ise varolanı kullan.
            }
        }
    }
}
