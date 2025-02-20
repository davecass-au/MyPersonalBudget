using Shared.Models.DTOs;
using Shared.Models.Entities.Interfaces;

namespace Shared.Models.Entities
{
    public class TransactionSingleInstanceEntity : TransactionSingleInstanceDto, IEntity<TransactionSingleInstanceDto>
    {
        public TransactionEntity Transaction { get; set; } = null!;

        public TransactionSingleInstanceDto ConvertToDto()
        {
            return new TransactionSingleInstanceDto
            {
                Id = this.Id,
                TransactionAmount = this.TransactionAmount,
                TransactionDate = this.TransactionDate,
                TransactionId = this.TransactionId
            };
        }

        public void Update(TransactionSingleInstanceDto updateWith)
        {
            this.TransactionId  = updateWith.TransactionId;
            this.TransactionAmount = updateWith.TransactionAmount;
            this.TransactionDate = updateWith.TransactionDate;
        }
    }
}
