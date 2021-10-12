using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BolsaDeEmpleo.BackEnd.API.Responses;
using BolsaDeEmpleo.BackEnd.Core.DTOs;
using BolsaDeEmpleo.BackEnd.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeEmpleo.BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobsOfferceService _jobService;
        private readonly IMapper _mapper;

        public JobOfferController(IJobsOfferceService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetJobs))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobService.GetJobs();
            var dto = _mapper.Map<IEnumerable<JobOfferDTO>>(jobs);
            var response = new ApiResponse<IEnumerable<JobOfferDTO>>(dto);
            return Ok(response);
        }
    }
}