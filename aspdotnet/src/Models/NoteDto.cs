namespace Workshop.Notes.WebApi.Models;
public static class Constants
{
  public const string SUCCESS_STATUS = "success";
}

public class NoteListDto
{
  public string Status { get; set; } = Constants.SUCCESS_STATUS;
  public int Results { get; set; } = 0;
  public IEnumerable<Note> Notes { get; set; } = new List<Note>();
}

public class NoteItemDto
{
  public string Status { get; set; } = Constants.SUCCESS_STATUS;
  public Note Note { get; set; }
}
