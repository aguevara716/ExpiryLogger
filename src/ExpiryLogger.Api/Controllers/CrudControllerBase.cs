using ExpiryLogger.Api.Helpers;
using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExpiryLogger.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public abstract class CrudControllerBase<T> : ControllerBase
		where T : IEntity
	{
		private readonly IRepository<T> _repository;

    protected CrudControllerBase(IRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var entities = _repository.Get();
        if (entities is null || !entities.Any())
            return NotFound();
        else
            return Ok(entities);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _repository.Get(id);
        if (entity is null)
            return NotFound();
        else
            return Ok(entity);
    }

    [HttpPost]
    public IActionResult Post([FromBody] T entity)
    {
        _ = _repository.Add(entity);
        return Ok(entity);
    }

    [HttpPut]
    public IActionResult Put([FromBody] T entity)
    {
        _ = _repository.Update(entity);
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var rowsDeleted = _repository.Delete(id);
        if (rowsDeleted == 0)
            return base.BadRequest($"Failed to delete entity with ID {id}");
        else
            return Ok(rowsDeleted);
    }
}
