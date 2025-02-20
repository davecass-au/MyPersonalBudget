using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;

namespace Application.Components
{
    public partial class AccountForm
    {
        [Parameter]
        public EventCallback<bool> FormClosed { get; set; }

        readonly AccountDto account = new();

        async Task Submit(AccountDto account)
        {
            await FormClosed.InvokeAsync((await dataService.Accounts.Add(account)) > 0);
        }

        async Task Cancel()
        {
            await FormClosed.InvokeAsync(false);
        }
    }
}