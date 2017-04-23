using Shipbob.Data.Entities.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shipbob.Data.Repository
{

  //Interface segregation principal demands a small focused interface, we could much more but shall focus on current requirements.
  public interface IRepository<TEntity> 
  {
      Task<IEnumerable<TEntity>> GetSomeByCriteria(int InitialCount, Func<TEntity, bool> criteria);

      Task<bool> AddEntityAsync(TEntity entity);

      Task<bool> UpdateEntityAsync(TEntity entity);
    
      Task<bool> RemoveEntityAsync(TEntity entity);

    }

    
}
