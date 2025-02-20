using Shared.Models.DTOs.Bases;
using Shared.Models.DTOs.Interfaces;
using Shared.Models.Entities;
using Shared.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models.DTOs
{
    public class TransactionRecurringInstanceDto : BaseDto, IDto<TransactionRecurringInstanceEntity>
    {
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public RecurringFrequency RecurringFrequency { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }
        public int? EndAfterCount { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double TransactionAmount { get; set; }


        public TransactionRecurringInstanceEntity ConvertToNewEntity()
        {
            return new TransactionRecurringInstanceEntity
            {
                Id = this.Id,
                TransactionId = this.TransactionId,
                TransactionAmount = this.TransactionAmount,
                StartDate = this.StartDate,
                RecurringFrequency = this.RecurringFrequency,
                EndDate = this.EndDate,
                EndAfterCount = this.EndAfterCount,
            };
        }
    }
}
