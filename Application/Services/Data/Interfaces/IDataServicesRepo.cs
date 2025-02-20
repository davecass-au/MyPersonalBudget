using Application.Services.Data.Dtos;

namespace Application.Services.Data.Interfaces
{
    public interface IDataServicesRepo
    {
        public AccountDataService Accounts { get; set; }
        public BalanceCorrectionDataService BalanceCorrections { get; set; }
        public TransactionDataService Transactions { get; set; }
        public TransactionSingleInstanceDataService TransactionSingleInstances { get; set; }
        public TransactionRecurringInstanceDataService TransactionRecurringInstances { get; set; }
    }
}
