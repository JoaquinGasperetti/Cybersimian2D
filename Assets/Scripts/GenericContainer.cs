using System.Collections.Generic;

public class GenericContainer<T>
{
    private List<T> items = new List<T>();

    public void Agregar(T item)
    {
        items.Add(item);
    }

    public List<T> ObtenerTodos()
    {
        return items;
    }

    public T ObtenerPrimero()
    {
        return items.Count > 0 ? items[0] : default;
    }
}