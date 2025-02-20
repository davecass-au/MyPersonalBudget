using Radzen.Blazor;
using Shared.Models.DTOs;

namespace Application.Pages
{
    public partial class BalanceCorrections
    {
        private List<BalanceCorrectionDto> gridData = new();
        private List<AccountDto> accounts = new();

        RadzenDataGrid<BalanceCorrectionDto> grid = new();

        private bool InRowEdit;

        string GetName(int id)
        {
            return accounts.First(x => x.Id == id).Name;
        }
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        async Task LoadData()
        {
            gridData = await data.BalanceCorrections.Get() ?? [];
            accounts = await data.Accounts.Get() ?? [];
        }

        async Task EditRow(BalanceCorrectionDto account)
        {
            InRowEdit = true;
            await grid.EditRow(account);
        }

        async Task InsertRow()
        {
            InRowEdit = true;
            await grid.InsertRow(new BalanceCorrectionDto());
        }

        async Task SaveRow(BalanceCorrectionDto toSave)
        {
            if (toSave.Id == 0)
            {
                toSave.Id = await data.BalanceCorrections.Add(toSave);
            }
            else
            {
                await data.BalanceCorrections.Update(toSave);
            }

            await grid.UpdateRow(toSave);
            InRowEdit = false;
        }

        async Task CancelEdit(BalanceCorrectionDto row)
        {
            InRowEdit = false;

            grid.CancelEditRow(row);

            await LoadData();
            await grid.Reload();
        }

        async Task DeleteRow(BalanceCorrectionDto toDelete)
        {
            await data.BalanceCorrections.Delete(toDelete.Id);
            grid.CancelEditRow(toDelete);

            await LoadData();
            await grid.Reload();
        }
    }
}