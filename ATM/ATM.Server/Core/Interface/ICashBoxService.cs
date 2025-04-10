using System.Diagnostics.CodeAnalysis;
using ATM.Server.Core.Implementation;
using ATM.Server.Models.Data;

namespace ATM.Server.Core.Interface
{
    public interface ICashBoxService
    {

        public CashDTO[] GetCashBoxes();

        public CashDTO? GetCashBox([NotNull] CashDTO cash);

        public int getTotalCashAmount();

        public void addCash([NotNull] CashDTO cash);

        public void removeCash([NotNull] CashDTO cash);

        public void removeCash([NotNull] List<CashDTO> cashList);

        public int[] getCashValues();

        public int[] getCoinAndBillCount();

        public string getCashType(CashDTO cashDTO);

    }
}
