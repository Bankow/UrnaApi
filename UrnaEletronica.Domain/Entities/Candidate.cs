using System;
using System.Collections.Generic;
using UrnaEletronica.Domain.Entities.Core;

namespace UrnaEletronica.Domain.Entities
{
    public class Candidate : IEntity
    {
        public Candidate()
        {
        }

        public Candidate(string name, string viceName, int subtitle)
            :this()
        {
            RegisterDate = DateTime.Now;
            Name = name;
            ViceName = viceName;
            Subtitle = subtitle;
        }

        public int CandidateId { get; private set; }

        public string Name { get; private set; }

        public string ViceName { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public int Subtitle { get; private set; }

        public IList<Vote> Votes { get; private set; }

    }
}
