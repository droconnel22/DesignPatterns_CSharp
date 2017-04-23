using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.GenericsDemo.Console
{
    public class Buffer<T> : IBuffer<T>
    {
        protected Queue<T>  _queue = new Queue<T>();
        
        public bool IsEmpty => this._queue.Count == 0;

        public virtual void Write(T value)
        {
           this._queue.Enqueue(value);
        }

        public virtual T Read()
        {
            return this._queue.Dequeue();
        }

     
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this._queue)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
