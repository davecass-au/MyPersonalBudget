using Application.Services.Data.Bases;
using Shared.Models.DTOs;

namespace Application.Services.Data.Dtos
{
    public class TransactionDataService(HttpClient httpClient) :
        BaseDataService<TransactionDto>(httpClient, uri)
    {
        private static readonly string uri = "api/transaction";


    }
}
