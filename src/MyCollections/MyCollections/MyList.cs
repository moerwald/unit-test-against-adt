using System.Collections.Generic;

namespace MyCollections
{
    public class MyList<T> : IMyList<T>
    {
        private readonly List<T> _lst = new List<T>();

        public void Append(T element) => _lst.Add(element);

        public void Clear() => _lst.Clear();

        public int Count() => _lst.Count;

        public T GetElementAt(int index) => _lst[index];
    }
}
