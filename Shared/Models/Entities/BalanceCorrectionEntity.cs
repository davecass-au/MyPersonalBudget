using Shared.Models.DTOs;
using Shared.Models.Entities.Interfaces;

namespace Shared.Models.Entities
{
    public class BalanceCorrectionEntity : BalanceCorrectionDto, IEntity<BalanceCorrectionDto>
    {
        public AccountEntity Account { get; set; } = null!;

        public BalanceCorrectionDto ConvertToDto()
        {
            return new BalanceCorrectionDto
            {
                Id = this.Id,
                AccountId = this.AccountId,
                CorrectionAmount = this.CorrectionAmount,
                CorrectionDate = this.CorrectionDate,
            };
        }

        public void Update(BalanceCorrectionDto updateWith)
        {
            this.AccountId = updateWith.AccountId;
            this.CorrectionDate = updateWith.CorrectionDate;
            this.CorrectionAmount = updateWith.CorrectionAmount;
        }
    }
}
