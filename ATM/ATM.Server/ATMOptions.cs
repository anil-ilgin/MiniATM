namespace ATM.Server
{
    public class ATMOptions
    {

        public Dictionary<string, int[]> CashTypes { get; set; } = new Dictionary<string, int[]>
        {
            { "BankNotes", Array.Empty<int>() },
            { "LargeCoins", Array.Empty<int>() },
            { "SmallCoins", Array.Empty<int>() }
        };
        public int maxCashBoxSize { get; set; }

        public int getAllCashBoxCount()
        {
           return CashTypes.Values.Sum(c => c.Length);
        }

    }
}
