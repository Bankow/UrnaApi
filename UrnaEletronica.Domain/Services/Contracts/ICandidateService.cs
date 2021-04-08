using System.Collections.Generic;
using UrnaEletronica.Domain.Dtos;
using UrnaEletronica.Domain.Entities;

namespace UrnaEletronica.Domain.Services.Contracts
{
    public interface ICandidateService
    {
        Candidate Create(CreateCandidateDto candidade);
        string Delete(int id);
        Candidate Get(int subtitle);
        IList<Candidate> GetAll();
    }
}
