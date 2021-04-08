using System;
using System.Collections.Generic;
using UrnaEletronica.Domain.Dtos;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Domain.Repositories;
using UrnaEletronica.Domain.Services.Contracts;

namespace UrnaEletronica.Domain.Services.Implementation
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;
        
        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Candidate Create(CreateCandidateDto candidade)
        {
            Candidate entity = new Candidate(candidade.Name, candidade.ViceName, candidade.Subtitle);

            _repository.Insert(entity);

            return entity;
        }

        public string Delete(int id)
        {
            var deleteData = _repository.Get(id);

            if (deleteData == null)
            {
                var returnMessage = string.Format("Candidate with Id '{0}' was previous deleted by another process in Database.", id);
                return returnMessage;
            }

            _repository.Delete(deleteData);

            return "Successfully deleted!";
        }

        public Candidate Get(int subtitle)
        {
            return _repository.GetBySubtitle(subtitle);
        }

        public IList<Candidate> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
