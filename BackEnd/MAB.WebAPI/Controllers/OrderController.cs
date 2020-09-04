using MAB.BusinessLogic.Interfaces;
using MAB.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderLogic _logic;
        public OrderController(IOrderLogic logic) => _logic = logic;

        [HttpGet]
        [Route("GetPaginatedOrder/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrder(int page, int rows) => Ok(_logic.GetPaginatedOrder(page, rows));

    }
}
