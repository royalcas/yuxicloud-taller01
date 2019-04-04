using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

using Services.Contracts;
using Services.DTO;

namespace Taller01WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValueService _valueService;

        public ValuesController(IValueService valueService)
        {
            this._valueService = valueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValueDTO>>> Get()
        {
            return Ok(await this._valueService.GetAllValues());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ValueDTO>> Get(int id)
        {
            var value = await this._valueService.GetValueById(id);
            if(value.HasValue)
                return Ok(value.Value);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {
            var result = await this._valueService.AddValue(value);
            if(result.IsSuccess)
                return Ok();
            else
                return UnprocessableEntity(result.Error);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] string value)
        {
            var result = await this._valueService.UpdateValue(id, value);
            if(result.IsSuccess)
                return Ok();
            else
                return UnprocessableEntity(result.Error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this._valueService.DeleteValue(id);
            if(result.IsSuccess)
                return Ok();
            else
                return UnprocessableEntity(result.Error);
        }
    }
}
