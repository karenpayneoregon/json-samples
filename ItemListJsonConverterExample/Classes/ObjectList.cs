using System.Collections;

namespace ItemListJsonConverterExample.Classes;

/// <summary>
/// Represents a generic list of objects with additional properties and functionality.
/// </summary>
/// <typeparam name="T">
/// The type of objects contained in the list. Must be a reference type.
/// </typeparam>
public class ObjectList<T> : IEnumerable<T> where T : class
{
    public string Group { get; set; }

    public int Count => Items.Count;

    public List<T> Items { get; set; } = [];

    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
}