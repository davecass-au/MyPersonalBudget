namespace Application.Helpers
{
    public static class DataGridHelpers
    {
        public static string GetCurrencyDisplayString(double value, bool displayZeros)
        {
            if (!displayZeros && value == 0) return string.Empty;

            return String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", value);
        }
    }
}
