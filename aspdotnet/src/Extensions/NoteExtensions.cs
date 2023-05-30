using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Notes.WebApi.Models;

namespace Workshop.Notes.WebApi.Extensions
{
  public static class NoteExtensions
  {
    public static NoteItemDto ToDto(this Note item) => new() {
      Note = item,
      Status = Models.Constants.SUCCESS_STATUS,
    };

    public static NoteListDto ToDto(this IEnumerable<Note> list) => new() {
      Notes = list,
      Results = list.Count(),
      Status = Models.Constants.SUCCESS_STATUS,
    };
  }
}