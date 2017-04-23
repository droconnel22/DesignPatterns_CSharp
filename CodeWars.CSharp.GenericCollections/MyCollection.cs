using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.GenericCollections
{
    /// <summary>
    /// ICollection adds
    /// 
    /// Count
    /// add
    /// Celar
    /// Contains
    /// Remove
    /// 
    /// to the IEnumberable interace, which itself only has GetEnumerator and Enumerate.
    /// </summary>


    interface IMyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
        void Add(T item);
        void Clear();
        void Contains(T item);
        bool Remove(T item);
    }
}
