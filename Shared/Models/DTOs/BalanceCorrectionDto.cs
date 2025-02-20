using Shared.Models.DTOs.Bases;
using Shared.Models.DTOs.Interfaces;
using Shared.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models.DTOs
{
    public class BalanceCorrectionDto : BaseDto, IDto<BalanceCorrectionEntity>
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public DateTime CorrectionDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double CorrectionAmount { get; set; }

        public BalanceCorrectionEntity ConvertToNewEntity()
        {
            return new BalanceCorrectionEntity
            {
                Id = this.Id,
                AccountId = this.AccountId,
                CorrectionAmount = this.CorrectionAmount,
                CorrectionDate = this.CorrectionDate
            };
        }
    }
}
