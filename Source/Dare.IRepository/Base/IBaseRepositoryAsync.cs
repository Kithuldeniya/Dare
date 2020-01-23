using System.Linq;
using System.Threading.Tasks;

namespace Dare.IRepository.Base
{
    public interface IBaseRepositoryAsync<TEntity>
        where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> InsertAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task<TEntity> DeleteAsync(TEntity id);
    }
}
