using API.Data;
using API.Services.Base;
using API.Services.Interfaces;
using Shared.Models.DTOs;
using Shared.Models.Entities;

namespace API.Services.Dtos
{
    public class TransactionService(MyBudgetDbContext db)
        : BaseService<TransactionDto, TransactionEntity>(db, db.Transactions), IService<TransactionDto>
    {
        public string RecordName => "Transaction";
    }
}
