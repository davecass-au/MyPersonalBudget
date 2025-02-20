using Application.Models;

namespace Application.Services.Interfaces
{
    public interface IBudgetService
    {
        public Task<List<BudgetGridRowEntry>> BuildBudgetEntries();

        public Dictionary<DateOnly, BudgetTotals> GetTotalsFromGridEntries(List<BudgetGridRowEntry> entries, List<DateOnly> dates);
    }
}
