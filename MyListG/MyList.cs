using System;
using System.Collections;
using System.Collections.Generic;

class MyList<T> : IList<T>
{
    private T[] list;
    private int size;
    public T this[int index]
    {
        get => list[index];
        set => list[index] = value;
    }
    public MyList() { size = 0; list = new T[size]; }
    public MyList(int size)
    {
        if (size >= 0)
            list = new T[size];
        else throw new ArgumentOutOfRangeException(size.ToString());
    }

    public int Count => size;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        if (list.Length > size)
        {
            list[size++] = item;
        }
        else
        {
            list.CopyTo(list = new T[size + 10], 0);
            list[size++] = item;
        }
    }

    public void Clear()
    {
        list = new T[0];
        size = 0;
    }

    public bool Contains(T item)
    {
        if ((Object)item == null)
        {
            for (int i = 0; i < Count; i++)
                if ((Object)list[i] == null)
                    return true;
            return false;
        }
        else
        {
            for (int i = 0; i < size; i++)
                if (list[i].Equals(item))
                    return true;
            return false;
        }
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Array.Copy(list, 0, array, arrayIndex, Count);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return list[i];
        }
    }

    public int IndexOf(T item)
    {
        if ((Object)item == null)
        {
            for (int i = 0; i < Count; i++)
                if ((Object)list[i] == null)
                    return i;
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                if (list[i].Equals(item))
                    return i;
            }
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (size == list.Length)
            list.CopyTo(list = new T[size + 10], 0);
        if (index < size)
            Array.Copy(list, index, list, index + 1, size - index);
        list[index] = item;
        size++;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }
        return false;
    }


    public void RemoveAt(int index)
    {
        if (index < size & index >= 0)
        {
            Array.Copy(list, index + 1, list, index, size - index);
            size--;
        }
        else throw new IndexOutOfRangeException(index.ToString());

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
