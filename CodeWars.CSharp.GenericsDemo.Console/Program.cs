using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.GenericsDemo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer<double>();
            ProcessInput(buffer);


            var consoleOut = new Printer<double>(ConsoleWrite);

            var asInts = buffer.AsEnumerableOf<double,string>();
            buffer.Dump(consoleOut);
            ProcessBuffer(buffer);

            System.Console.Read();
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {

            var sum = 0.0;
            System.Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }

            System.Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {

            while (true)
            {
                var value = 0.0;
                var input = System.Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;

            }

        }


        public static void ConsoleWrite<T>(T data)
        {
            System.Console.WriteLine(data);
        }


    }
}
