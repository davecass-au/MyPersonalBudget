using Application.Services.Data.Dtos;
using Application.Services.Data.Interfaces;

namespace Application.Services.Data.Repository
{
    public class DataServicesRepo(HttpClient httpClient) : IDataServicesRepo
    {
        public AccountDataService Accounts { get; set; } = new(httpClient);
        public BalanceCorrectionDataService BalanceCorrections { get; set; } = new(httpClient);
        public TransactionDataService Transactions { get; set; } = new(httpClient);
        public TransactionSingleInstanceDataService TransactionSingleInstances { get; set; } = new(httpClient);
        public TransactionRecurringInstanceDataService TransactionRecurringInstances { get; set; } = new(httpClient);
    }
}
