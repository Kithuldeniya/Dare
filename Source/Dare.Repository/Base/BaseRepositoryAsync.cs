using Dare.IRepository.Base;
using Dare.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dare.Repository.Base
{
    public class BaseRepositoryAsync<TEntity> : 
        IBaseRepositoryAsync<TEntity>
        where TEntity : class
    {

        private readonly DareDBContext _dbContext;
        public BaseRepositoryAsync(DareDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<TEntity> DeleteAsync(TEntity id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
