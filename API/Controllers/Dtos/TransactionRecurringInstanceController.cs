using API.Controllers.Base;
using API.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTOs;

namespace API.Controllers.Dtos
{
    [Route("api/transactionrecurringinstance")]
    [ApiController]
    public class TransactionRecurringInstanceController(IServicesRepository servicesRepository)
        : BaseController<TransactionRecurringInstanceDto>(servicesRepository.TransactionRecurringInstances)
    {
        // -- Inherited from BaseController --
    }
}
