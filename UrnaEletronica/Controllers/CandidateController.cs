using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UrnaEletronica.Domain.Dtos;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Domain.Services.Contracts;

namespace UrnaEletronica.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;


        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public Candidate Create([FromBody]CreateCandidateDto candidate)
        {
            return _candidateService.Create(candidate);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _candidateService.Delete(id);
        }

        [HttpGet("{subtitle}")]
        public Candidate Get(int subtitle)
        {
            return _candidateService.Get(subtitle);

        }

        [HttpGet("GetAll")]
        public IList<Candidate> GetAll()
        {
            return _candidateService.GetAll();
        }
    }
}
