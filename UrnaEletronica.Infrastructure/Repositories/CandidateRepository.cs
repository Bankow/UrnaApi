using ReleaseManager.Infrastructure.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Domain.Repositories;
using UrnaEletronica.Infrastructure.Repositories.Core;

namespace UrnaEletronica.Infrastructure.Repositories
{
    public sealed class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(UrnaEletronicaContext dbContext) : base(dbContext)
        {
        }

        public Candidate Get(int id)
        {
            return Query().FirstOrDefault(x => x.CandidateId == id);
        }

        public Candidate GetBySubtitle(int subtitle)
        {
            return Query().FirstOrDefault(x => x.Subtitle == subtitle);
        }

        public IList<Candidate> GetAll()
        {
            try
            {
                return Query().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
