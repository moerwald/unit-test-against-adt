using System;

namespace MyCollections
{
    public class MyArray<T> : IMyList<T>
    {
        private T[] _entries;
        private int _index;
        private readonly int _capacity;

        public MyArray(int capacity = 50)
        {
            _entries = new T[capacity];
            _capacity = capacity;
        }

        public void Append(T element)
        {
            ResizeIfNeeded();
            _entries[_index] = element;
            _index++;
        }

        private void ResizeIfNeeded()
        {
            if (_index >= _entries.Length)
                Array.Resize(ref _entries, _entries.Length + 30);
        }

        public void Clear()
        {
            _entries = new T[_capacity];
            _index = 0;
        }

        public int Count() => _index;

        public T GetElementAt(int index)
        {
            if (_index == 0)
                throw new Exception("Collection is empty");

            return _entries[
                index >= _entries.Length
                ? throw new IndexOutOfRangeException($"Actual max index: {_entries.Length - 1}")
                : index];
        }
    }
}
