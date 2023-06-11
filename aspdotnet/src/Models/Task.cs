using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Workshop.Notes.WebApi.Models;

public class Task : BaseItem
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }
}
