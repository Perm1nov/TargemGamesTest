using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class MyList<T> : IList<T>
{
    private T[] list = new T[0];
    private int counter = 0;
    public T this[int index]
    {
        get => list[index];
        set => list[index] = value;
    }
    public MyList() { }
    public MyList(int size)
    {
        if (size >= 0)
            list = new T[size];
        else throw new ArgumentOutOfRangeException(size.ToString());
    }

    public int Count => counter;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        if (list.Length > counter)
        {
            list[counter++] = item;
        }
        else
        {
            list.CopyTo(list = new T[counter + 10], 0);
            list[counter++] = item;
        }
    }

    public void Clear()
    {
        list = new T[0];
        counter = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < counter; i++)
        {
            if (list[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        try
        {
            for (int i = 0; i < counter; i++)
            {
                array[arrayIndex + i] = list[i];
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < counter; i++)
        {
            yield return list[i];
        }
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < counter; i++)
        {
            if (list[i].Equals(item))
                return i;
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < counter)
        {
            list[index] = item;
        }
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index>=0)
        {
            RemoveAt(index);
            return true;
        }
        return false;
    }


    public void RemoveAt(int index)
    {
        list = list.Where((val, ind) => ind != index).ToArray();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
