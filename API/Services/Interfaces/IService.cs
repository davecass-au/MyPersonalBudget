namespace API.Services.Interfaces
{
    public interface IService<T> : IBaseService<T>
    {
        public string RecordName { get; }

    }
}
