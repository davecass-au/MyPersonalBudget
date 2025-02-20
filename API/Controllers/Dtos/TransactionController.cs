using API.Controllers.Base;
using API.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTOs;

namespace API.Controllers.Dtos
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController(IServicesRepository servicesRepository)
        : BaseController<TransactionDto>(servicesRepository.Transactions)
    {
        // -- Inherited from BaseController --
    }
}
