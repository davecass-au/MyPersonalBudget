namespace Application.Models
{
    public class BudgetTotals
    {
        public double ExpenseTotal { get; set; }
        public double IncomeTotal { get; set; }
        public double TotalDifference => IncomeTotal - ExpenseTotal;


        public double Total { get; set; } 
        public double RunningBalance { get; set; }

    }
}
