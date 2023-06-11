using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Notes.WebApi.Models;

namespace Workshop.Notes.WebApi.Services;

public class InMemoryStore<T> : IStore<T> where T : BaseItem
{
    private readonly List<T> _store = new();
    private static int CalculateOffset(int limit, int page) => (page - 1) * limit;

    public IEnumerable<T> List(int limit, int page) => _store.Skip(CalculateOffset(limit, page)).Take(limit);
    // .Where(e => e.Title.Contains(search))
    public IEnumerable<T> List(string search, int limit, int page) => _store.Skip(CalculateOffset(limit, page)).Take(limit);
    public IEnumerable<T> List(Func<T, bool> predicate) => _store.Where(predicate);
    public IEnumerable<T> List(Func<T, bool> predicate, int limit, int page) => _store.Where(predicate).Skip(CalculateOffset(limit, page)).Take(limit);

    public T? Get(Guid id) => _store.Find(e => e.Id == id);
    public T? Get(Predicate<T> predicate) => _store.Find(predicate);

    public void Add(T item) => _store.Add(item);

    public void Remove(T item) => _store.Remove(item);
    public void Remove(Guid id) => _store.RemoveAll(e => e.Id == id);

    public void Replace(T item)
    {
        Remove(item.Id);
        Add(item);
    }

    public bool Any(Func<T, bool> predicate) => _store.Any(predicate);
    public bool Any() => _store.Any();

    public int Count(Func<T, bool> predicate) => _store.Count(predicate);
    public int Count() => _store.Count;
}
