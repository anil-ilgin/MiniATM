using ATM.Server.Models.Data;
using ATM.Server.Models.Request;
using ATM.Server.Models.Response;

namespace ATM.Server.Core.Interface
{
    public interface ICashOperationService
    {
        public InternalResponseCashWithdraw WithdrawCash(InternalRequestCashWithdraw amount);

    }
}
