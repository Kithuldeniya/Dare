using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dare.IRepository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Insert(TEntity obj);
        TEntity Update(TEntity obj);
        TEntity Delete(TEntity id);
    }
}
