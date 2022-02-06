using BackOfficePOS.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _dataContext;

        public BuggyController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var pro = _dataContext.Products.Find(434);
            if(pro == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var pro = _dataContext.Products.Find(434);
            var pro1 = pro.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int Id)
        {
            return Ok();
        }
    }
}
