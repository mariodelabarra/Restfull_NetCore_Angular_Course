using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAB.BusinessLogic.Interfaces;
using MAB.Models;
using MAB.UnitOfWork;
using MAB.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierLogic _logic;
        public SupplierController(ISupplierLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_logic.GetById(id));
        }

        [HttpPost]
        [Route("GetPaginatedSupplier")]
        public IActionResult GetPaginatedSupplier([FromBody] GetPaginatedSupplier request)
        {
            return Ok(_logic.SupplierPagedList(request.Page, request.Rows, request.searchTerm));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(supplier));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid && _logic.Update(supplier))
            {
                return Ok(new { Message = "The Supplier is Updated." });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Supplier supplier)
        {
            if (supplier.Id > 0)
            {
                return Ok(_logic.Delete(supplier));
            }

            return BadRequest();
        }
    }
}
