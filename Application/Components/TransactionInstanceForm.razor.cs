using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using Shared.Models.Enums;

namespace Application.Components
{
	public partial class TransactionInstanceForm
	{
        [Parameter]
        public EventCallback<bool> FormClosed { get; set; }

        public int TransactionId { get; set; }

        List<TransactionDto> transactions = [];

        TransactionInstanceType SelectedInstanceType { get; set; }

        readonly TransactionSingleInstanceDto singleInstance = new();

        IEnumerable<TransactionInstanceType> transactionInstanceTypes = Enum.GetValues(typeof(TransactionInstanceType)).Cast<TransactionInstanceType>();

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        async Task LoadData()
        {
            transactions = await dataService.Transactions.Get() ?? [];
        }

        async Task Close()
        {
            await FormClosed.InvokeAsync(false);
        }
    }
}