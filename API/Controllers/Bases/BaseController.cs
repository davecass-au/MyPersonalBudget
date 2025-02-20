using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTOs.Interfaces;

namespace API.Controllers.Base
{
    public class BaseController<T>(IService<T> service) : ControllerBase where T : IBaseDto
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            T? record = service.Get(id);

            return record != null ? Ok(record) : NotFound($"The {service.RecordName} record could not be found.");
        }

        [HttpPost]
        public IActionResult Post([FromBody] T record)
        {
            try
            {
                if (record == null)
                {
                    return BadRequest($"{service.RecordName} is null.");
                }

                int newId = service.Add(record);

                return Ok(newId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] T record)
        {
            try
            {
                if (record == null)
                {
                    return BadRequest($"{service.RecordName} is null.");
                }

                T? toUpdate = service.Get(id);

                if (toUpdate == null)
                {
                    return NotFound($"The {service.RecordName} record could not be found.");
                }

                service.Update(id, record);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                T? record = service.Get(id);

                if (record == null)
                {
                    return NotFound($"The {service.RecordName} record could not be found.");
                }

                service.Delete(record);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
