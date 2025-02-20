using Shared.Models.DTOs;
using Shared.Models.Entities.Interfaces;

namespace Shared.Models.Entities
{
    public class AccountEntity : AccountDto, IEntity<AccountDto>
    {
        public ICollection<BalanceCorrectionEntity> BalanceCorrections { get; } = [];

        public ICollection<TransactionEntity> TransactionsTo { get; } = [];

        public ICollection<TransactionEntity> TransactionsFrom { get; } = [];

        public AccountDto ConvertToDto()
        {
            return new AccountDto
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }

        public void Update(AccountDto updateWith)
        {
            this.Name = updateWith.Name;
            this.Description = updateWith.Description;
        }
    }
}
