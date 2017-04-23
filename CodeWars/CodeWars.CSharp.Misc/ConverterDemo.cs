using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{
    public class ConverterDemo
    {

        Converter<double,DateTime> converter = d => new DateTime(2016,12,14).AddDays(d);

        
    }



    public interface IBuffer<T>
    {
        bool IsEmpty { get; }
        void Write(T value);
        T Read();
    }



    public static class BufferExtensions
    {
        public static IEnumerable<TOutput> Map<T, TOutput>(
            this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            throw new NotImplementedException();
        }
    }
}
