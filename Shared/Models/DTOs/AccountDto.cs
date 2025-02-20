using Shared.Models.DTOs.Bases;
using Shared.Models.DTOs.Interfaces;
using Shared.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models.DTOs
{
    public class AccountDto : BaseDto, IDto<AccountEntity>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public AccountEntity ConvertToNewEntity()
        {
            return new AccountEntity
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}
