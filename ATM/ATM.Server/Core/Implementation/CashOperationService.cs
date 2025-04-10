using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using ATM.Server.Core.Interface;
using ATM.Server.Models.Data;
using ATM.Server.Models.Request;
using ATM.Server.Models.Response;

namespace ATM.Server.Core.Implementation
{
    public class CashOperationService : ICashOperationService
    {
        private ICashBoxService CashBoxService { get; set; }

        public CashOperationService(ICashBoxService cashBoxService)
        {
            CashBoxService = cashBoxService;
        }

        public InternalResponseCashWithdraw WithdrawCash(InternalRequestCashWithdraw request)
        {
            if (CashBoxService == null)
            {
                throw new InvalidOperationException("CashBoxService is not initialized.");
            }

            int amount = request.withdrawRequestAmount;
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            if (amount > CashBoxService.getTotalCashAmount())
            {
                throw new ArgumentException("Not enough cash in the ATM");
            }

            try
            {

                var result = CoinChange(amount);
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].setCashType(CashBoxService.getCashType(result[i]));
                }
                CashBoxService.removeCash(result);


                return new InternalResponseCashWithdraw(result);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error while withdrawing cash", e);
            }
        }

        private List<CashDTO> CoinChange(int amount)
        {

            CashDTO[] cashList = CashBoxService.GetCashBoxes();


            int INF = int.MaxValue / 2; 
            int[] dp = new int[amount + 1];
            Dictionary<int, int>[] used = new Dictionary<int,int>[amount + 1];
            Array.Fill(used, new Dictionary<int, int>());

            for (int i = 0; i <= amount; i++)
            {
                dp[i] = INF;
            }

            dp[0] = 0;

            for (int i = 0; i < cashList.Length; i++)
            {
                int coin = cashList[i].getCashAmount();
                int count = cashList[i].getCashQuantity();
                string type = cashList[i].getCashType();
                int k = 1;

                while (count > 0)
                {
                    int use = Math.Min(k, count);
                    int value = coin * use;

                    for (int j = amount; j >= value; j--)
                    {
                        if (dp[j - value] != INF && dp[j] > dp[j - value] + use)
                        {
                            dp[j] = dp[j - value] + use;
                            var newDict = new Dictionary<int, int>(used[j - value]);
                            newDict[coin] = newDict.ContainsKey(coin) ? newDict[coin] + use : use;
                            used[j] = newDict;
                        }
                    }

                    count -= use;
                    k *= 2;
                }
            }

            if (dp[amount] == INF)
                throw new ArgumentException("Not enough cash in the ATM.");



            return used[amount].Select(kvp => new CashDTO(kvp.Key,kvp.Value, "")).ToList();
        }
    }
}
