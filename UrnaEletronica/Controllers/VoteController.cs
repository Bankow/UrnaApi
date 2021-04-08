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
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;


        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost]
        public bool Create([FromBody] int candidateId)
        {
            return _voteService.Create(candidateId) != null;
        }

        [HttpGet]
        public IList<VoteDto> GetAll()
        {
            return _voteService.GetAll();
        }
    }
}
