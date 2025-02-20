
namespace Shared.Models.DTOs.Interfaces
{
    public interface IDto<EntityT>
    {
        EntityT ConvertToNewEntity();
    }
}
