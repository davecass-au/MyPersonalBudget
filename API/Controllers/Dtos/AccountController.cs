using API.Controllers.Base;
using API.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTOs;

namespace API.Controllers.Dtos
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IServicesRepository servicesRepository)
        : BaseController<AccountDto>(servicesRepository.Accounts)
    {
        // -- Inherited from BaseController --
        // GET: api/Account
        // GET: api/Account/5
        // POST: api/Account
        // PUT: api/Account/5
        // DELETE: api/Account/5
    }
}
