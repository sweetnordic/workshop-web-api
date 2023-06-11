using Microsoft.AspNetCore.Mvc;
using Workshop.Notes.WebApi.Extensions;
using Workshop.Notes.WebApi.Models;
using Workshop.Notes.WebApi.Services;

namespace Workshop.Notes.WebApi.Controllers;

[ApiController, Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
[Route("notes")]
public class NotesController : ControllerBase
{
    private readonly ILogger<NotesController> _logger;
    private readonly INoteStore _store;

    public NotesController(INoteStore store, ILogger<NotesController> logger)
    {
        _store = store;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NoteListDto))]
    public async Task<ActionResult<NoteItemDto>> List([FromQuery] int limit = 10, [FromQuery] int page = 1, [FromQuery] string search = "")
    {
        _logger.LogInformation("GetNotes({page}, {limit}, {search})", page, limit, search);
        var list = _store.List(search, limit, page);
        return Ok(list.ToDto());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NoteItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NoteItemDto>> GetById([FromRoute] Guid id)
    {
        _logger.LogInformation("GetNoteById({id})", id);
        Note? item = _store.Get(id);
        return null == item ? NotFound() : Ok(item.ToDto());
    }

    [HttpPost, Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NoteItemDto))]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NoteItemDto>> Post([FromBody] Note item)
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
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] Note item)
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
