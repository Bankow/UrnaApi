using System.Collections.Generic;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Domain.Repositories.Core;

namespace UrnaEletronica.Domain.Repositories
{
    public interface IVoteRepository : IRepository<Vote>
    {
        IList<Vote> GetAll();
    }
}
