using BackendApiTest.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace BackendApiTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController<T> : ControllerBase where T : class
    {
        protected IActionResult ReturnList(List<T> result)
        => Ok(result);
       
        protected IActionResult ReturnSingle(T? result)
        => result is null ? NotFound() : Ok(result);

        protected IActionResult ReturnResult(BaseChangeEntityResult result)
        {
            switch (result)
            {
                case BaseChangeEntityResult.Success:
                    return NoContent();
                case BaseChangeEntityResult.NotFound:
                    return NotFound();
            }
            return BadRequest();
        }
        protected IActionResult DeletedUpdatedResult()
        => NoContent();

        //the crud results are handled by a base class so in the future if we wanted to change the return result or add a message or return type
        //we can do it much easier
    }
}
