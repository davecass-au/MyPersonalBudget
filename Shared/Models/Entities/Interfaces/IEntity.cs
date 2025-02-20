namespace Shared.Models.Entities.Interfaces
{
    public interface IEntity<T>
    {
        T ConvertToDto();

        void Update(T updateWith);
    }
}
