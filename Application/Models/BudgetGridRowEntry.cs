
namespace Application.Models
{
    public class BudgetGridRowEntry
    {
        public string AccountName { get; set; } = string.Empty;
        public string TransactionName { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public Dictionary<DateOnly, double> ValuesByDate { get; set; } = [];
    }
}
