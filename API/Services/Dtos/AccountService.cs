using API.Data;
using API.Services.Base;
using API.Services.Interfaces;
using Shared.Models.DTOs;
using Shared.Models.Entities;

namespace API.Services.Dtos
{
    public class AccountService(MyBudgetDbContext db)
        : BaseService<AccountDto, AccountEntity>(db, db.Accounts), IService<AccountDto>
    {
        public string RecordName => "Account";
    }
}
