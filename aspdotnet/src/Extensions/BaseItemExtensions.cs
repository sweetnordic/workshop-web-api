using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Notes.WebApi.Models;

namespace Workshop.Notes.WebApi.Extensions;

public static class BaseItemExtensions
{
    public static BaseItemDto<BaseItem> ToDto(this BaseItem item) => new()
    {
        Value = item,
        Status = Models.Constants.SUCCESS_STATUS,
    };

    public static BaseListDto<BaseItem> ToDto(this IEnumerable<BaseItem> list) => new()
    {
        Value = list,
        Results = list.Count(),
        Status = Models.Constants.SUCCESS_STATUS,
    };
}
