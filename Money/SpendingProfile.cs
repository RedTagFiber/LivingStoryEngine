namespace LivingStoryEngine.Financial
{
    /// <summary>
    /// Full financial model for a character:
    /// - Money (balance, income, bills, debt)
    /// - Spending Profile (budget categories)
    /// </summary>
    public class SpendingProfile
    {
        // ============================
        // MONEY CORE
        // ============================

        public decimal Balance { get; set; }
        public decimal WeeklyIncome { get; set; }
        public decimal MonthlyBills { get; set; }
        public decimal Savings { get; set; }
        public decimal Debt { get; set; }
        public int FinancialStress { get; set; }

        // ============================
        // SPENDING CATEGORIES
        // ============================

        public decimal Bills { get; set; }
        public decimal Food { get; set; }
        public decimal Entertainment { get; set; }
        public decimal SavingsRate { get; set; }
        public decimal HobbySpending { get; set; }

        // ============================
        // CONSTRUCTOR
        // ============================

        public SpendingProfile()
        {
            Balance = 0;
            WeeklyIncome = 0;
            MonthlyBills = 0;
            Savings = 0;
            Debt = 0;
            FinancialStress = 0;

            Bills = 0;
            Food = 0;
            Entertainment = 0;
            SavingsRate = 0;
            HobbySpending = 0;
        }
    }
}
