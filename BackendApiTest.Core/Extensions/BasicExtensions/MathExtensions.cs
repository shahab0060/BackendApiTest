namespace BackendApiTest.Core.Extensions.BasicExtensions
{
    public static class MathExtensions
    {
        public static int Round(this int value, int roundValue)
        => value % roundValue >= (roundValue / 2) ? value + roundValue - value % roundValue : value - value % roundValue;

        public static int CalculatePercentValue(this int totalValue, int customValue)
        {
            if (customValue > 0)
                return (customValue * 100) / totalValue;
            return customValue;
        }
    }
}
