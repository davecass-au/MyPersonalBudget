using API.Data;
using API.Services.Base;
using API.Services.Interfaces;
using Shared.Models.DTOs;
using Shared.Models.Entities;

namespace API.Services.Dtos
{
    public class BalanceCorrectionService(MyBudgetDbContext db)
        : BaseService<BalanceCorrectionDto, BalanceCorrectionEntity>(db, db.BalanceCorrections), IService<BalanceCorrectionDto>
    {
        public string RecordName => "Balance Correction";
    }
}
