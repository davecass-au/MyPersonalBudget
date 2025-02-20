using Shared.Models.DTOs;
using Shared.Models.Entities.Interfaces;

namespace Shared.Models.Entities
{
    public class TransactionRecurringInstanceEntity : TransactionRecurringInstanceDto, IEntity<TransactionRecurringInstanceDto>
    {
        public TransactionEntity Transaction { get; set; } = null!;

        public TransactionRecurringInstanceDto ConvertToDto()
        {
            return new TransactionRecurringInstanceDto
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

        public void Update(TransactionRecurringInstanceDto updateWith)
        {
            this.TransactionId = updateWith.TransactionId;
            this.TransactionAmount = updateWith.TransactionAmount;
            this.RecurringFrequency = updateWith.RecurringFrequency;
            this.StartDate = updateWith.StartDate;
            this.EndDate = updateWith.EndDate;
            this.EndAfterCount = updateWith.EndAfterCount;
        }
    }
}
