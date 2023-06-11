using System.Text.Json.Serialization;

namespace Workshop.Notes.WebApi.Models;

public class BaseListDto<T> where T : BaseItem
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = Constants.SUCCESS_STATUS;

    [JsonPropertyName("restults")]
    public int Results { get; set; } = 0;

    [JsonPropertyName("value")]
    public IEnumerable<T> Value { get; set; } = new List<T>();
}

public class BaseItemDto<T> where T : BaseItem
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = Constants.SUCCESS_STATUS;

    [JsonPropertyName("value")]
    public T Value { get; set; }
}
