namespace Workshop.Notes.WebApi.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Notes.WebApi.Models;

public interface INoteStore
{
  public IEnumerable<Note> List(int limit, int page);
  public IEnumerable<Note> List(string search, int limit, int page);
  public IEnumerable<Note> List(Func<Note, bool> predicate);
  public IEnumerable<Note> List(Func<Note, bool> predicate, int limit, int page);

  public Note? Get(Guid id);
  public Note? Get(Predicate<Note> predicate);

  public void Add(Note item);

  public void Remove(Note item);
  public void Remove(Guid id);

  public void Replace(Note item);

  public bool Any();
  public bool Any(Func<Note, bool> predicate);

  public int Count();
  public int Count(Func<Note, bool> predicate);
}