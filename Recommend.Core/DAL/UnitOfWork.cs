using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recommend.Core.Models;

namespace Recommend.Core.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecommendationsContext _context;
        private GenericRepository<User> _usersRepository;
        private GenericRepository<Place> _placesRepository;
        private GenericRepository<Recommendation> _recomendationsRepository;

        public UnitOfWork()
        {
            _context = new RecommendationsContext();
        }

        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new RecommendationsContext(nameOrConnectionString);
        }

        private GenericRepository<T> GetRepositoryLazy<T>(GenericRepository<T> repository)
            where T : Entity
        {
            return repository ?? (repository = new GenericRepository<T>(_context));
        }

        public IGenericRepository<Recommendation> Recommendations
        {
            get { return GetRepositoryLazy(_recomendationsRepository); }
        }

        public IGenericRepository<Place> Places
        {
            get { return GetRepositoryLazy(_placesRepository); }
        }

        public IGenericRepository<User> Users
        {
            get { return GetRepositoryLazy(_usersRepository); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
