using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Workshop.Notes.WebApi.Models;

public class BaseItem
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }

}
