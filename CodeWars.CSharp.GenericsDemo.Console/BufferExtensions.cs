using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CodeWars.CSharp.GenericsDemo.Console
{

    public delegate void Printer<T>(T data);

    public static class BufferExtensions
    {
        public static IEnumerable<TOutput> AsEnumerableOf<T,TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                yield return (TOutput)converter.ConvertTo(item, typeof(TOutput));
            }
        }


        public static IEnumerable<TOutput> Map<T, TOutput>(this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            throw new NotImplementedException();
        }

        public static void Dump<T>(this IBuffer<T> buffer, Printer<T> printer)
        {
            foreach (var item in buffer)
            {
                printer(item);
            }
        }
    }
}