using System;
using System.Collections.Generic;
using System.Text;

namespace MyCollections
{
    public interface IMyList<T>
    {
        int Count();
        void Append(T element);
        void Clear();
        T GetElementAt(int index);
    }
}
