using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.GenericsDemo.Console
{
    public class CircularBuffer<T> : Buffer<T>
    {
        private readonly int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            this._capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (this._queue.Count > this._capacity)
            {
                this._queue.Dequeue();
            }
        }

        public bool IsFull => this._queue.Count == this._capacity;
    }
}
