using Application.Services.Data.Bases;
using Shared.Models.DTOs;

namespace Application.Services.Data.Dtos
{
    public class AccountDataService(HttpClient httpClient) : BaseDataService<AccountDto>(httpClient, uri)
    {
        private static readonly string uri = "api/account";


        //protected override string Uri { get => "api/account"; }

        //public async Task<List<AccountDto>?> NewMEthod()
        //{
        //    return await HttpClient.GetFromJsonAsync<List<AccountDto>>("api/account");
        //}

    }
}
