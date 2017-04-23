using System.Collections.Generic;

namespace CodeWars.CSharp.GenericsDemo.Console
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        void Write(T value);
        T Read();
    }
}