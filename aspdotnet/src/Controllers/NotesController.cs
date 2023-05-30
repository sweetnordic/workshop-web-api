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
  public async Task<IActionResult> Get([FromQuery] int limit = 10, [FromQuery] int page = 1, [FromQuery] string search = "")
  {
    _logger.LogInformation("GetNotes({page}, {limit}, {search})", page, limit, search);
    var list = _store.List(search, limit, page);
    return Ok(list.ToDto());
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NoteItemDto))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Get([FromRoute] Guid id)
  {
    _logger.LogInformation("GetNoteById({id})", id);
    Note? item = _store.Get(id);
    return null == item ? NotFound() : Ok(item.ToDto());
  }

  [HttpPost, Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NoteItemDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Post([FromBody] Note item)
  {
    _logger.LogInformation("PostNote({item})", item);
    _store.Add(item);
    return CreatedAtAction(nameof(Get), new { id = item.Id }, item.ToDto());
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> Patch([FromRoute] Guid id, [FromBody] Note item) {
    var old = _store.Get(id);
    if (null == old) {
      return NotFound();
    }

    return BadRequest();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Delete([FromRoute] Guid id)
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
