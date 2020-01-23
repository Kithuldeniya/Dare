using Dare.IRepository.Base;
using Dare.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dare.Repository.Base
{
    public class BaseRepository<TEntity> :
        IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DareDBContext _dbContext;
        public BaseRepository(DareDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Delete(TEntity id)
        {
            throw new NotImplementedException();
        }


        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
