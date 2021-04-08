using Microsoft.EntityFrameworkCore;
using ReleaseManager.Infrastructure.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Domain.Repositories;
using UrnaEletronica.Infrastructure.Repositories.Core;

namespace UrnaEletronica.Infrastructure.Repositories
{
    public sealed class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(UrnaEletronicaContext dbContext) : base(dbContext)
        {
        }

        public IList<Vote> GetAll()
        {
            try
            {
                return Query().Include(x => x.Candidate).ToList();

            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
