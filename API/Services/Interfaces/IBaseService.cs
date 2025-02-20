namespace API.Services.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> Get();
        T? Get(int id);
        int Add(T toAdd);
        void Update(int id, T updatedRecord);
        void Delete(T toDelete);
    }
}
