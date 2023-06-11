using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Notes.WebApi.Models;

namespace Workshop.Notes.WebApi.Services;

public interface IStore<T> where T : BaseItem
{
    public IEnumerable<T> List(int limit, int page);
    public IEnumerable<T> List(string search, int limit, int page);
    public IEnumerable<T> List(Func<T, bool> predicate);
    public IEnumerable<T> List(Func<T, bool> predicate, int limit, int page);

    public T? Get(Guid id);
    public T? Get(Predicate<T> predicate);

    public void Add(T item);

    public void Remove(T item);
    public void Remove(Guid id);

    public void Replace(T item);

    public bool Any();
    public bool Any(Func<T, bool> predicate);

    public int Count();
    public int Count(Func<T, bool> predicate);
}
