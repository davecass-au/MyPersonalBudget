using Application.Services.Data.Bases;
using Shared.Models.DTOs;

namespace Application.Services.Data.Dtos
{
    public class TransactionSingleInstanceDataService(HttpClient httpClient) :
        BaseDataService<TransactionSingleInstanceDto>(httpClient, uri)
    {
        private static readonly string uri = "api/transactionsingleinstance";


    }
}
