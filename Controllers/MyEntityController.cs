using Microsoft.AspNetCore.Mvc;
using SolidPrincipalWithDecoratorPatternAndDbContext.Service;
using SolidPrincipalWithGenericDbContext.Model;
using SolidPrincipalWithGenericDbContext.Service;
using System.Xml;

namespace SolidPrincipalWithGenericDbContext.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyEntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public MyEntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        // GET api/myentity/{tenantId}
        [HttpGet("{tenantId}")]
        public async Task<IActionResult> GetAllEntities(string tenantId)
        {
            try
            {
                var entities = await _entityService.GetAllEntitiesAsync(tenantId);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // POST api/myentity/{tenantId}
        [HttpPost("{tenantId}")]
        public async Task<IActionResult> AddEntity(string tenantId, [FromBody] MyEntity newEntity)
        {
            try
            {
                var createdEntity = await _entityService.AddEntityAsync(tenantId, newEntity);
                return CreatedAtAction(nameof(GetAllEntities), new { tenantId }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // PUT api/myentity/{tenantId}/{id}
        [HttpPut("{tenantId}/{id}")]
        public async Task<IActionResult> UpdateEntity(string tenantId, string id, [FromBody] MyEntity updatedEntity)
        {
            try
            {
                var entity = await _entityService.UpdateEntityAsync(tenantId, id, updatedEntity);
                return Ok(entity);
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // DELETE api/myentity/{tenantId}/{id}
        [HttpDelete("{tenantId}/{id}")]
        public async Task<IActionResult> DeleteEntity(string tenantId, string id)
        {
            try
            {
                await _entityService.DeleteEntityAsync(tenantId, id);
                return NoContent();
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}
