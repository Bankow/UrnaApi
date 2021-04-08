using System;
using System.ComponentModel.DataAnnotations;
using UrnaEletronica.Domain.Entities.Core;

namespace UrnaEletronica.Domain.Entities
{
    public class Vote : IEntity
    {
        public Vote(int candidateId)
            :this()
        {
            CandidateId = candidateId;
            VoteDate = DateTime.Now;
        }

        public Vote()
        {
        }

        public int VoteId { get; private set; }

        public int CandidateId { get; private set; }

        public DateTime VoteDate { get; private set; }

        public Candidate Candidate { get; private set; }
    }
}
