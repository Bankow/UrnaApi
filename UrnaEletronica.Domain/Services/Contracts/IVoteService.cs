using System.Collections.Generic;
using UrnaEletronica.Domain.Dtos;
using UrnaEletronica.Domain.Entities;

namespace UrnaEletronica.Domain.Services.Contracts
{
    public interface IVoteService
    {
        IList<VoteDto> GetAll();
        Vote Create(int candidateId);
    }
}
