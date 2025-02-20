using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Shared.Models.DTOs;
using Shared.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Components
{
    public partial class TransactionForm
    {
        [Parameter]
        public EventCallback<bool> FormClosed { get; set; }

        readonly TransactionDto transaction = new();

        private List<AccountDto> accounts = new();
        IEnumerable<TransactionType> transactionTypes = Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>();

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        async Task LoadData()
        {
            accounts = await dataService.Accounts.Get() ?? [];
        }

        async Task Submit(TransactionDto transaction)
        {
            await FormClosed.InvokeAsync((await dataService.Transactions.Add(transaction)) > 0);
        }

        async Task Cancel()
        {
            await FormClosed.InvokeAsync(false);
        }
    }
}