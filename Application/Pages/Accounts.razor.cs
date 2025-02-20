using Radzen.Blazor;
using Shared.Models.DTOs;

namespace Application.Pages
{
    public partial class Accounts
    {
        private List<AccountDto> accounts = new();
        RadzenDataGrid<AccountDto> accountsGrid = new();

        private bool InRowEdit;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }
        
        async Task LoadData()
        {
            accounts = await data.Accounts.Get() ?? [];
        }

        async Task EditRow(AccountDto account)
        {
            InRowEdit = true;
            await accountsGrid.EditRow(account);
        }

        async Task InsertRow()
        {
            InRowEdit = true;
            await accountsGrid.InsertRow(new AccountDto());
        }

        async Task SaveRow(AccountDto account)
        {
            if (account.Id == 0) 
            { 
                account.Id = await data.Accounts.Add(account);
            }
            else
            {
               await data.Accounts.Update(account);
            }

            await accountsGrid.UpdateRow(account);
            InRowEdit = false;
        }

        async Task CancelEdit(AccountDto account)
        {
            InRowEdit = false;

            accountsGrid.CancelEditRow(account);

            await LoadData();
            await accountsGrid.Reload();
        }

        async Task DeleteRow(AccountDto account)
        {
            await data.Accounts.Delete(account.Id);
            accountsGrid.CancelEditRow(account);

            await LoadData();
            await accountsGrid.Reload();
        }
    }
}