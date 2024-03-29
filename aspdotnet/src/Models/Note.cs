using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Workshop.Notes.WebApi.Models;

public class Note : BaseItem
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public string Category { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool Published { get; set; } = false;
}
