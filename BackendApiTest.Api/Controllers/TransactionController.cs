using BackendApiTest.Core.Services.Interfaces;
using BackendApiTest.Domain.ViewModels.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace BackendApiTest.WebApi.Controllers
{
    /// <summary>
    /// مدیریت تراکنش ها
    /// </summary>
    public class TransactionController : BaseApiController<TransactionListDto>
    {
        #region constructor

        private readonly ITransactionService _service;
        public TransactionController(ITransactionService service)
        {
            this._service = service;
        }

        #endregion

        #region get list

        /// <summary>
        /// به دست آوردن لیست تراکنش ها
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetTransactionReport")]
        public async Task<IActionResult> GetList([FromQuery] filterTransactionsDto filter)
        => ReturnList(await _service.FilterTransactions(filter));

        #endregion

        #region create

        /// <summary>
        /// افزودن تراکنش
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionDto create)
        => ReturnResult(await _service.CreateTransaction(create));

        #endregion

        #region update

        /// <summary>
        /// بروزرسانی تراکنش
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTransactionDto update)
        => ReturnResult(await _service.UpdateTransaction(update));

        #endregion

        #region delete

        /// <summary>
        /// حذف تراکنش
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        => ReturnResult(await _service.DeleteTransaction(id));

        #endregion
    }
}
