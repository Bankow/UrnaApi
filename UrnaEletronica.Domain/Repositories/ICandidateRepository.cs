using System.Collections.Generic;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Domain.Repositories.Core;

namespace UrnaEletronica.Domain.Repositories
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Candidate Get(int id);

        Candidate GetBySubtitle(int subtitle);

        IList<Candidate> GetAll();
    }
}
