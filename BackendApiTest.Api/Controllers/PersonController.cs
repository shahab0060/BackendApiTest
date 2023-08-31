using BackendApiTest.Core.Services.Interfaces;
using BackendApiTest.Domain.ViewModels.Person;
using Microsoft.AspNetCore.Mvc;

namespace BackendApiTest.WebApi.Controllers
{
    /// <summary>
    /// مدیریت کاربر ها
    /// </summary>
    public class PersonController : BaseApiController<PersonListDto>
    {
        #region constructor

        private readonly IPersonService _service;
        public PersonController(IPersonService service)
        {
            this._service = service;
        }

        #endregion

        #region get list

        /// <summary>
        /// به دست آوردن لیست کاربران
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] filterPeopleDto filter)
        => ReturnList(await _service.FilterPeople(filter));

        #endregion

        #region get max buyer

        /// <summary>
        /// به دست آوردن بالاترین قیمت خریدار
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetMaxBuyer")]
        public async Task<IActionResult> GetMaxBuyer()
        => Ok(await _service.GetMaxBuyer());

        #endregion

        #region get max buyer in date

        /// <summary>
        /// به دست آوردن بالاترین قیمت خریدار
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetMaxBuyerInDate")]
        public async Task<IActionResult> GetMaxBuyerInDate([FromQuery] FilterMaxBuyerDto filter)
        => ReturnSingle(await _service.GetMaxBuyer(filter));

        #endregion

        #region create

        /// <summary>
        /// افزودن کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonDto create)
        => ReturnResult(await _service.CreatePerson(create));

        #endregion

        #region update

        /// <summary>
        /// بروزرسانی کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonDto update)
        => ReturnResult(await _service.UpdatePerson(update));

        #endregion

        #region delete

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        => ReturnResult(await _service.DeletePerson(id));

        #endregion
    }
}
