using API.Data;
using API.Services.Base;
using API.Services.Interfaces;
using Shared.Models.DTOs;
using Shared.Models.Entities;

namespace API.Services.Dtos
{
    public class TransactionRecurringInstanceService(MyBudgetDbContext db)
        : BaseService<TransactionRecurringInstanceDto, TransactionRecurringInstanceEntity>(db, db.TransactionRecurringInstances), IService<TransactionRecurringInstanceDto>
    {
        public string RecordName => "Recurring Transaction Instance";
    }
}
