using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities; // DBEntities için eklendi.

namespace Data.Repositories
{
    // Diğer classlara base olacak abstract classım.
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private Agt_Project_DBEntities _dbContext;

        public BaseRepository(Agt_Project_DBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity List(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
    }
}
