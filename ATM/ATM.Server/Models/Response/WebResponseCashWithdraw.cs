using System.Text.Json.Serialization;
using ATM.Server.Models.Data;



namespace ATM.Server.Models.Response
{
    public class WebResponseCashWithdraw
    {
        [JsonPropertyName("withdrawedCashAmounts")]
        public List<CashDTO> withdrawedCashAmounts { get; set; }

        public WebResponseCashWithdraw()
        {
            withdrawedCashAmounts = new List<CashDTO>();
        }

        public WebResponseCashWithdraw(List<CashDTO> withdrawedCashAmounts)
        {
            this.withdrawedCashAmounts = withdrawedCashAmounts;
        }

    }
}
