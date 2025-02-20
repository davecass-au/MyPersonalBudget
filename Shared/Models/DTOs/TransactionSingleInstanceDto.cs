using Shared.Models.DTOs.Bases;
using Shared.Models.DTOs.Interfaces;
using Shared.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models.DTOs
{
    public class TransactionSingleInstanceDto : BaseDto, IDto<TransactionSingleInstanceEntity>
    {
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double TransactionAmount { get; set; }

        public TransactionSingleInstanceEntity ConvertToNewEntity()
        {
            return new TransactionSingleInstanceEntity
            {
                Id = this.Id,
                TransactionId = this.TransactionId,
                TransactionAmount = this.TransactionAmount,
                TransactionDate = this.TransactionDate,
            };
        }
    }
}
