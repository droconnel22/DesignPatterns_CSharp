
namespace CodeWars.CodeWars.CSharp.Concurrency
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SingleThreadBenchmark
    {
        public void TimeDict(IDictionary<int, int> dictionary, int dictionarySize)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            stopWatch.Restart();

        }
    }
}
