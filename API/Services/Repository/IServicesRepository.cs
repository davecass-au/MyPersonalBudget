using API.Services.Dtos;

namespace API.Services.Repository
{
    public interface IServicesRepository
    {
        public AccountService Accounts { get; set; }

        public BalanceCorrectionService BalanceCorrections { get; set; }

        public TransactionService Transactions { get; set; }

        public TransactionRecurringInstanceService TransactionRecurringInstances { get; set; }

        public TransactionSingleInstanceService TransactionSingleInstances { get; set; }
    }
}
