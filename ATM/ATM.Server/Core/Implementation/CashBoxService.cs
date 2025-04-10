using System.Diagnostics.CodeAnalysis;
using ATM.Server.Core.Interface;
using ATM.Server.Models.Data;
using System.Linq;

namespace ATM.Server.Core.Implementation
{
    public class CashBoxService : ICashBoxService
    {

        private CashDTO[] _cashBoxes;
        public CashBoxService()
        {
            _cashBoxes = [];
            ;
        }

        public CashBoxService(ATMOptions options)
        {
            _cashBoxes = new CashDTO[options.getAllCashBoxCount()];
            int i = 0;
            foreach (var cashType in options.CashTypes)
            {
                foreach (var cash in cashType.Value)
                {
                    _cashBoxes[i++] = new CashDTO(cash, options.maxCashBoxSize, cashType.Key);
                }
            }
            return;
        }


        public CashDTO[] GetCashBoxes()
        {
            return _cashBoxes;

        }
        public CashDTO? GetCashBox([NotNull] CashDTO cash)
        {
           return _cashBoxes.FirstOrDefault(c => c.getCashAmount() == cash.getCashAmount());
        }

        public int getTotalCashAmount()
        {
            int totalCash = 0;
            foreach (var cashType in _cashBoxes)
            {
                totalCash += cashType.getCashAmount() * cashType.getCashQuantity();

            }
            return totalCash;
        }

        public void addCash([NotNull] CashDTO cash)
        {
           var cashBox = GetCashBox(cash);
            if (cashBox != null)
            {
                cashBox.addCash(cash.getCashQuantity());
            }
            else
            {
                this._cashBoxes = [..this._cashBoxes, cash];
            }
        }

        public void removeCash([NotNull] CashDTO cash)
        {
            var cashBox = GetCashBox(cash);
            if (cashBox != null)
            {
                cashBox.removeCash(cash.getCashQuantity());
            }
            else
            {
                throw new Exception("Cash type not found");
            }

        }

        public void removeCash([NotNull] List<CashDTO> cashList)
        {
            foreach (var cash in cashList)
            {
                var cashBox = GetCashBox(cash);
                if (cashBox != null)
                {
                    cashBox.removeCash(cash.getCashQuantity());
                }
                else
                {
                    throw new Exception("Cash type not found");
                }
            }
        }

        public int[] getCashValues()
        {
            return _cashBoxes.OrderBy(cash => cash.getCashAmount())
                .Select(cash => cash.getCashAmount())
                .ToArray();
        }

        public int[] getCoinAndBillCount()
        {
            return _cashBoxes.OrderBy(cash => cash.getCashAmount())
                .Select(cash => cash.getCashQuantity())                        
                .ToArray();

        }

        public string getCashType(CashDTO cashDTO)
        {
            return _cashBoxes.Select(cashBox => cashBox)
                .FirstOrDefault(cash => cash.getCashAmount() == cashDTO.getCashAmount())?
                .getCashType() ?? string.Empty;
        }
    }
}
