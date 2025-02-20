using Application.Services.Data.Bases;
using Shared.Models.DTOs;

namespace Application.Services.Data.Dtos
{
    public class TransactionRecurringInstanceDataService(HttpClient httpClient) :
        BaseDataService<TransactionRecurringInstanceDto>(httpClient, uri)
    {
        private static readonly string uri = "api/transactionrecurringinstance";


    }
}
