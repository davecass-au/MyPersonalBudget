using Application.Models;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using Radzen.Blazor.Rendering;
using Shared.Models.DTOs;

namespace Application.Pages
{
    public partial class Budget
    {
        
        RadzenDataGrid<BudgetGridRowEntry> grid = new();

        Dictionary<DateOnly, BudgetTotals> totalsByDate = [];

        public List<DateOnly> DatesToDisplay { get; set; } = [];
        public List<BudgetGridRowEntry> GridData { get; set; } = [];

        RadzenButton createAccountButton = new();
        Popup accountPopup = new();

        RadzenButton createTransactionButton = new();
        Popup transactionPopup = new();

        RadzenButton createInstanceButton = new();
        Popup transactionInstancePopup = new();

        bool IsLoading = true;

        protected override async Task OnInitializedAsync()
        {
            BuildDates();
            await Reload();
        }

        async Task Reload()
        {
            IsLoading = true;



            GridData = await budgetService.BuildBudgetEntries();

            totalsByDate = budgetService.GetTotalsFromGridEntries(GridData, DatesToDisplay);
            StateHasChanged();
            IsLoading = false;
        }

        void OnRender(DataGridRenderEventArgs<BudgetGridRowEntry> args)
        {
            if (args.FirstRender)
            {
                //args.Grid.Groups.Add(new GroupDescriptor() { Property = "AccountName", SortOrder = SortOrder.Descending });
                //args.Grid.Groups.Add(new GroupDescriptor() { Property = "TransactionType", SortOrder = SortOrder.Descending });
                StateHasChanged();
            }
        }

        async Task OnOpen()
        {
            await JSRuntime.InvokeVoidAsync("eval", "setTimeout(function(){ document.getElementById('search').focus(); }, 200)");
        }

        private double GetValueByDate(BudgetGridRowEntry entry, DateOnly date)
        {
            return entry.ValuesByDate.TryGetValue(date, out double value) ? value : 0;
        }

        private double GetRunningBalanceByDate(DateOnly date)
        {
            return totalsByDate.TryGetValue(date, out BudgetTotals? totals) ? totals.RunningBalance : 0;
        }

        private double GetTotalByDate(List<BudgetGridRowEntry> entries, DateOnly date)
        {
            double total = 0;

            // TODO... could be a better way
            foreach (var entry in entries)
            {
                total += GetValueByDate(entry, date);
            }
            return total;
        }

        public void BuildDates()
        {
            // TODO - Dynamically set to 7 entries (or optional).
            // TODO - Options to change the dates (move forward and backward)
            // TODO - Support other than single dates (weekly, monthly, etc)
            DatesToDisplay = [
                new DateOnly(2024, 7, 1),
                new DateOnly(2024, 7, 2),
                new DateOnly(2024, 7, 3),
                new DateOnly(2024, 7, 4),
                new DateOnly(2024, 7, 5),
            ];
        }

        async Task AccountFormClosed(bool wasAdded)
        {
            await accountPopup.CloseAsync();

            if (wasAdded) await Reload();
        }
        async Task TransactionFormClosed(bool wasAdded)
        {
            await transactionPopup.CloseAsync();

            if (wasAdded) await Reload();
        }

        async Task TransactionInstanceFormClosed(bool wasAdded)
        {
            await Reload();

            //await transactionInstancePopup.CloseAsync();

            //if (wasAdded) await Reload();
        }
    }
}