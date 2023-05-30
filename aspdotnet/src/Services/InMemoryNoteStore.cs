using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Notes.WebApi.Models;

namespace Workshop.Notes.WebApi.Services;

public class InMemoryNoteStore : INoteStore
{
  private readonly List<Note> _store = new();
  private int CalculateOffset(int limit, int page) => (page - 1) * limit;

  public IEnumerable<Note> List(int limit, int page) => _store.Skip(CalculateOffset(limit, page)).Take(limit);
  public IEnumerable<Note> List(string search, int limit, int page) => _store.Where(e => e.Title.Contains(search)).Skip(CalculateOffset(limit, page)).Take(limit);
  public IEnumerable<Note> List(Func<Note, bool> predicate) => _store.Where(predicate);
  public IEnumerable<Note> List(Func<Note, bool> predicate, int limit, int page) => _store.Where(predicate).Skip(CalculateOffset(limit, page)).Take(limit);

  public Note? Get(Guid id) => _store.Find(e => e.Id == id);
  public Note? Get(Predicate<Note> predicate) => _store.Find(predicate);

  public void Add(Note item) => _store.Add(item);

  public void Remove(Note item) => _store.Remove(item);
  public void Remove(Guid id) => _store.RemoveAll(e => e.Id == id);

  public void Replace(Note item) {
    Remove(item.Id);
    Add(item);
  }

  public bool Any(Func<Note, bool> predicate) => _store.Any(predicate);
  public bool Any() => _store.Any();

  public int Count(Func<Note, bool> predicate) => _store.Count(predicate);
  public int Count() => _store.Count;
}
