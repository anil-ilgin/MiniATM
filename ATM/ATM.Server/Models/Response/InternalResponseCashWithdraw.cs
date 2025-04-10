using ATM.Server.Models.Data;

namespace ATM.Server.Models.Response
{
    public class InternalResponseCashWithdraw
    {
        private List<CashDTO> withdrawedCashAmounts { get; set; }

        public InternalResponseCashWithdraw()
        {
            withdrawedCashAmounts = new List<CashDTO>();
        }

        public InternalResponseCashWithdraw(List<CashDTO> withdrawedCashAmounts)
        {
            this.withdrawedCashAmounts = withdrawedCashAmounts;
        }


        public List<CashDTO> getWithdrawResults()
        {
            return withdrawedCashAmounts;
        }

        public void setWithdrawResults(List<CashDTO> withdrawedCashAmounts)
        {
            this.withdrawedCashAmounts = withdrawedCashAmounts;
        }

    }
}
