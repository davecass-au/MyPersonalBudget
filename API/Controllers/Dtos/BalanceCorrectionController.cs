using API.Controllers.Base;
using API.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTOs;

namespace API.Controllers.Dtos
{
    [Route("api/balancecorrection")]
    [ApiController]
    public class BalanceCorrectionController(IServicesRepository servicesRepository)
        : BaseController<BalanceCorrectionDto>(servicesRepository.BalanceCorrections)
    {
        // -- Inherited from BaseController --
        // GET: api/BalanceCorrection
        // GET: api/BalanceCorrection/5
        // POST: api/BalanceCorrection
        // PUT: api/BalanceCorrection/5
        // DELETE: api/BalanceCorrection/5
    }
}
