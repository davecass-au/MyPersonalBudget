using API.Data;
using API.Services.Dtos;

namespace API.Services.Repository
{
    public class ServicesRepository(MyBudgetDbContext db) : IServicesRepository
    {
        public AccountService Accounts { get; set; } = new(db);

        public BalanceCorrectionService BalanceCorrections { get; set; } = new(db);

        public TransactionService Transactions { get; set; } = new(db);

        public TransactionRecurringInstanceService TransactionRecurringInstances { get; set; } = new(db);

        public TransactionSingleInstanceService TransactionSingleInstances { get; set; } = new(db);
    }
}
