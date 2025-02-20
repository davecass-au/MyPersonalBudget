using Application.Services.Data.Interfaces;
using Shared.Models.DTOs.Bases;
using System.Net.Http.Json;

namespace Application.Services.Data.Bases
{
    public class BaseDataService<T>(HttpClient httpClient, string uri) : IBaseDataService<T> where T : BaseDto
    {
        public async Task<List<T>?> Get()
        {
            return await httpClient.GetFromJsonAsync<List<T>>(uri);
        }

        public async Task<T?> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<T>($"{uri}/{id}");
        }

        public async Task<int> Add(T toAdd)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri, toAdd);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>(); 
            }
            
            return 0;
        }

        public async Task<bool> Update(T toUpdate)
        {
            return (await httpClient.PutAsJsonAsync($"{uri}/{toUpdate.Id}", toUpdate)).IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            return (await httpClient.DeleteAsync($"{uri}/{id}")).IsSuccessStatusCode;
        }
    }
}
