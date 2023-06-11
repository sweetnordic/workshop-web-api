using Microsoft.AspNetCore.Mvc;
using Workshop.Notes.WebApi.Extensions;
using Workshop.Notes.WebApi.Models;
using Workshop.Notes.WebApi.Services;

namespace Workshop.Notes.WebApi.Controllers;

[ApiController, Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;
    private readonly IStore<Models.Task> _store;

    public TasksController(IStore<Models.Task> store, ILogger<TasksController> logger)
    {
        _store = store;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseListDto<Models.Task>))]
    public async Task<ActionResult<BaseListDto<Models.Task>>> List([FromQuery] int limit = 10, [FromQuery] int page = 1, [FromQuery] string search = "")
    {
        _logger.LogInformation("GetNotes({page}, {limit}, {search})", page, limit, search);
        var list = _store.List(search, limit, page);
        return Ok(list.ToDto());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseItemDto<Models.Task>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseItemDto<Models.Task>>> GetById([FromRoute] Guid id)
    {
        _logger.LogInformation("GetNoteById({id})", id);
        Models.Task? item = _store.Get(id);
        return null == item ? NotFound() : Ok(item.ToDto());
    }

    [HttpPost, Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BaseItemDto<Models.Task>))]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseItemDto<Models.Task>>> Post([FromBody] Models.Task item)
    {
        _logger.LogInformation("PostNote({item})", item);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _store.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item.ToDto());
    }

    [HttpPut("{id}"), Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] Models.Task item)
    {
        _logger.LogInformation("PutNote({item})", item);

        var old = _store.Get(id);
        if (null == old)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (old.UpdatedAt != item.UpdatedAt)
        {
            ModelState.AddModelError("UpdatedAt", "Item has been updated at the Server");
            return BadRequest(ModelState);
        }
        _store.Replace(item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        _logger.LogInformation("DeleteNote({id})", id);
        if (_store.Any(e => e.Id == id))
        {
            return NotFound();
        }

        _store.Remove(id);
        return NoContent();
    }
}
