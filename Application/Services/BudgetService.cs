using Application.Models;
using Application.Services.Data.Interfaces;
using Application.Services.Interfaces;
using Shared.Models.DTOs;

namespace Application.Services
{
    public class BudgetService(IDataServicesRepo dataServices) : IBudgetService
    {
        public IDataServicesRepo DataServices { get; } = dataServices;

        public async Task<List<BudgetGridRowEntry>> BuildBudgetEntries()
        {
            List<BudgetGridRowEntry> BudgetEntries = [];

            // Use APIs to get the required data ...
            var ac = await DataServices.Accounts.Get();
            var transactions = await DataServices.Transactions.Get();
            var singleInstances = await DataServices.TransactionSingleInstances.Get();

            if (ac != null && transactions != null && singleInstances != null)
            {
                foreach (var a in ac)
                {
                    var outgoings = transactions.Where(x => x.FromAccountId == a.Id);

                    foreach (var outgo in outgoings)
                    {
                        var singles = singleInstances.Where(x => x.TransactionId == outgo.Id);

                        BudgetGridRowEntry toAdd = new()
                        {
                            AccountName = a.Name,
                            TransactionType = outgo.TransactionType.ToString(),
                            TransactionName = outgo.Name
                        };

                        foreach (var s in singles)
                        {
                            toAdd.ValuesByDate.Add(new DateOnly(s.TransactionDate.Year, s.TransactionDate.Month, s.TransactionDate.Day), s.TransactionAmount * -1);
                        }

                        BudgetEntries.Add(toAdd);
                    }

                    var incoming = transactions.Where(x => x.ToAccountId == a.Id);

                    foreach (var income in incoming)
                    {
                        var singles = singleInstances.Where(x => x.TransactionId == income.Id);

                        BudgetGridRowEntry toAdd = new()
                        {
                            AccountName = a.Name,
                            TransactionType = income.TransactionType.ToString(),
                            TransactionName = income.Name
                        };

                        foreach (var s in singles)
                        {
                            toAdd.ValuesByDate.Add(new DateOnly(s.TransactionDate.Year, s.TransactionDate.Month, s.TransactionDate.Day), s.TransactionAmount);
                        }

                        BudgetEntries.Add(toAdd);
                    }
                }
            }
            return BudgetEntries;
        }

        public Dictionary<DateOnly, BudgetTotals> GetTotalsFromGridEntries(List<BudgetGridRowEntry> entries, List<DateOnly> dates)
        {
            Dictionary<DateOnly, BudgetTotals> totals = [];

            // TODO - starting balance

            totals.Add(dates.First().AddDays(-1), new BudgetTotals { RunningBalance = 0});

            foreach (var date in dates.Select((value, i) => new { i, value }))
            {
                BudgetTotals toAdd = new BudgetTotals { Total = GetTotalByDate(entries, date.value) };
                toAdd.RunningBalance = totals.ElementAt(date.i).Value.RunningBalance + toAdd.Total;

                totals.Add(date.value, toAdd);
            }

            return totals;
        }

        private double GetValueByDate(BudgetGridRowEntry entry, DateOnly date)
        {
            return entry.ValuesByDate.TryGetValue(date, out double value) ? value : 0;
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
    }
}
