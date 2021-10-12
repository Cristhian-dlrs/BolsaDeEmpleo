using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeEmpleo.BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobsOfferceService _jobService;

        public JobOfferController(IJobsOfferceService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet(Name = nameof(GetJobs))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetJobs()
        {
            return Ok(await _jobService.GetJobs());
        }
    }
}