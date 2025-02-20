using Shared.Models.DTOs.Bases;
using Shared.Models.DTOs.Interfaces;
using Shared.Models.Entities;
using Shared.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models.DTOs
{
    public class TransactionDto : BaseDto, IDto<TransactionEntity>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public int? FromAccountId { get; set; }

        public int? ToAccountId { get; set; }

        public TransactionType TransactionType { get; set; }

        public TransactionEntity ConvertToNewEntity()
        {
            return new TransactionEntity
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                FromAccountId = this.FromAccountId,
                ToAccountId = this.ToAccountId,
                TransactionType = this.TransactionType
            };
        }
    }
}
