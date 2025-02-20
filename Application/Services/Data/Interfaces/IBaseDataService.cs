namespace Application.Services.Data.Interfaces
{
    public interface IBaseDataService<T>
    {
        Task<List<T>?> Get();

        Task<T?> GetById(int id);

        Task<int> Add(T toAdd);

        Task<bool> Update(T toUpdate);

        Task<bool> Delete(int id);
    }
}
