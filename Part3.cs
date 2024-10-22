using System;
using System.Collections.Generic;

public class CustomDictionary<TKey, TValue>
{
    private class Entry
    {
        public TKey Key;
        public TValue Value;
        public Entry Next;

        public Entry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    private Entry[] _buckets;
    private int _size;

    public CustomDictionary(int capacity = 16)
    {
        _buckets = new Entry[capacity];
        _size = 0;
    }

    private int GetBucketIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % _buckets.Length;
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetBucketIndex(key);
        Entry newEntry = new Entry(key, value);

        if (_buckets[index] == null)
        {
            _buckets[index] = newEntry;
        }
        else
        {
            Entry current = _buckets[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists.");
                }
                if (current.Next == null)
                {
                    current.Next = newEntry;
                    break;
                }
                current = current.Next;
            }
        }
        _size++;
    }

    public TValue Get(TKey key)
    {
        int index = GetBucketIndex(key);
        Entry current = _buckets[index];

        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                return current.Value;
            }
            current = current.Next;
        }

        throw new KeyNotFoundException("Key not found.");
    }

    public void Remove(TKey key)
    {
        int index = GetBucketIndex(key);
        Entry current = _buckets[index];
        Entry previous = null;

        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                if (previous == null)
                {
                    _buckets[index] = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                _size--;
                return;
            }
            previous = current;
            current = current.Next;
        }

        throw new KeyNotFoundException("Key not found.");
    }

    public int Count => _size;
}


class Program
{
    static void Main()
    {
        var myDict = new CustomDictionary<string, int>();

        myDict.Add("One", 1);
        myDict.Add("Two", 2);
        myDict.Add("Three", 3);
        Console.WriteLine(myDict.Get("Two")); 
        myDict.Remove("One");
        Console.WriteLine(myDict.Count);
    }
}
