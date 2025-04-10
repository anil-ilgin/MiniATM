using System.Net;
using ATM.Server.Core.Interface;
using ATM.Server.Models.Request;
using ATM.Server.Models.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Server.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")] // Apply CORS only to this controller
    [ApiController]
    public class CashOperationsController : ControllerBase
    {
        private readonly ICashOperationService _cashOperationService;

        public CashOperationsController(ICashOperationService cashOperationService)
        {
            _cashOperationService = cashOperationService;
        }

        [HttpPost("withdraw")]
        public IActionResult WithdrawCash([FromBody] WebRequestCashWithdraw request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            try
            {
                InternalRequestCashWithdraw internalRequest = new InternalRequestCashWithdraw();
                internalRequest.withdrawRequestAmount = request.withdrawRequestAmount;

                var response = _cashOperationService.WithdrawCash(internalRequest);
                WebResponseCashWithdraw webResponse = new WebResponseCashWithdraw(response.getWithdrawResults());

                return Ok(webResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
