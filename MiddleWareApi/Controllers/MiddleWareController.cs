using Microsoft.AspNetCore.Mvc;
using MiddleWareApi.Data;
using MiddleWareApi.Filters;
using System.Reflection;

namespace MiddleWareApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    [LogSensitive]
    public class MiddleWareController : ControllerBase
    {
        private readonly AppDbContext _dbc;
        public MiddleWareController(AppDbContext dbc)
        {
            _dbc = dbc;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<MiddleWare>> Get()
        {
            var records = _dbc.Set<MiddleWare>();
            return Ok(records);
        }
        [HttpGet]
        [Route("MiddleWareId")]
        public ActionResult<MiddleWare> GetById(int id)
        {
            var record = _dbc.Set<MiddleWare>().Find(id);
            return record == null ? NotFound() : Ok(record);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<int>> CreateMiddleWare(MiddleWare middle)
        {
            middle.MiddleWareId = 0;
            _dbc.Set<MiddleWare>().Add(middle);
            await _dbc.SaveChangesAsync();
            return Ok(middle);
        }
        [HttpPut]
        [Route("")]
        public  ActionResult UpdateMiddleWare(MiddleWare middle)
        {
            var existingMiddleWare=_dbc.Set<MiddleWare>().Find(middle.MiddleWareId);
            existingMiddleWare.MiddleWareName = middle.MiddleWareName;
            existingMiddleWare.MiddleWareDescription = middle.MiddleWareDescription;
            _dbc.Set<MiddleWare>().Update(existingMiddleWare);
            _dbc.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        [Route("")]
        public ActionResult DeleteMiddleWare(int id) 
        {
            var existingMiddleWare = _dbc.Set<MiddleWare>().Find(id);
            _dbc.Set<MiddleWare>().Remove(existingMiddleWare);
            _dbc.SaveChanges();
            return Ok();
        }

    }
}
