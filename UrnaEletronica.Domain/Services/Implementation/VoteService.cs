using System;
using System.Collections.Generic;
using System.Linq;
using UrnaEletronica.Domain.Dtos;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Domain.Repositories;
using UrnaEletronica.Domain.Services.Contracts;

namespace UrnaEletronica.Domain.Services.Implementation
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _repository;

        public VoteService(IVoteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Vote Create(int candidateId)
        {
            try
            {
                Vote vote = new Vote(candidateId);

                _repository.Insert(vote);

                return vote;
            } catch
            {
                return null;
            }
        }

        public IList<VoteDto> GetAll()
        {
          var result = _repository.GetAll();

            return result.GroupBy(x => x.CandidateId).Select(n =>
            {
                var Candidate = result.FirstOrDefault(x => x.CandidateId == n.Key).Candidate;

                return new VoteDto
                {
                    CandidateId = n.Key,
                    Votes = n.Count(),
                    Name = Candidate.Name,
                    ViceName = Candidate.ViceName,
                    Subtitle = Candidate.Subtitle
                };
            }).OrderByDescending(x => x.Votes).ToList();
        }
    }
}
