using API.Controllers.Base;
using API.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTOs;

namespace API.Controllers.Dtos
{
    [Route("api/transactionsingleinstance")]
    [ApiController]
    public class TransactionSingleInstanceController(IServicesRepository servicesRepository)
        : BaseController<TransactionSingleInstanceDto>(servicesRepository.TransactionSingleInstances)
    {
        // -- Inherited from BaseController --
    }
}
