using API.Data;
using API.Services.Base;
using API.Services.Interfaces;
using Shared.Models.DTOs;
using Shared.Models.Entities;

namespace API.Services.Dtos
{
    public class TransactionSingleInstanceService(MyBudgetDbContext db)
        : BaseService<TransactionSingleInstanceDto, TransactionSingleInstanceEntity>(db, db.TransactionSingleInstances), IService<TransactionSingleInstanceDto>
    {
        public string RecordName => "Single Transaction Instance";
    }
}
