using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recommend.Core.Models;

namespace Recommend.Core.DAL
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private RecommendationsContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(RecommendationsContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual IQueryable<TEntity> List()
        {
            IQueryable<TEntity> query = _dbSet;

            return _dbSet;
        }
    }
}
