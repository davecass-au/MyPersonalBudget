using Shared.Models.DTOs;
using Shared.Models.Entities.Interfaces;

namespace Shared.Models.Entities
{
    public class TransactionEntity : TransactionDto, IEntity<TransactionDto>
    {
        public AccountEntity? FromAccount { get; set; } = null;

        public AccountEntity? ToAccount { get; set; } = null;

        public TransactionDto ConvertToDto()
        {
            return new TransactionDto
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                FromAccountId = this.FromAccountId,
                ToAccountId = this.ToAccountId,
                TransactionType = this.TransactionType,

            };
        }

        public void Update(TransactionDto updateWith)
        {
            this.Name = updateWith.Name;
            this.Description = updateWith.Description;
            this.FromAccountId = updateWith.FromAccountId;
            this.ToAccountId = updateWith.ToAccountId;
            this.TransactionType = updateWith.TransactionType;
        }
    }
}
