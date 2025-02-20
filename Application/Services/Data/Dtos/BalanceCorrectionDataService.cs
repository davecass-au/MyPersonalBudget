using Application.Services.Data.Bases;
using Shared.Models.DTOs;

namespace Application.Services.Data.Dtos
{
    public class BalanceCorrectionDataService(HttpClient httpClient) : BaseDataService<BalanceCorrectionDto>(httpClient, uri)
    {
        private static readonly string uri = "api/balancecorrection";


    }
}
