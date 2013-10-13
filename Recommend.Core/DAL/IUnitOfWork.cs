using Recommend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommend.Core.DAL
{
    public interface IUnitOfWork
    {
        IGenericRepository<Recommendation> Recommendations { get; }
        IGenericRepository<Place> Places { get; }
        IGenericRepository<User> Users { get; }

        void Save();
    }
}
