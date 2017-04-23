using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.FlexibilityDemo.Common;

namespace CodeWars.FlexibilityDemo
{
    /// <summary>
    /// Advice on OO Design
    /// Start fromt he feature consumer
    /// 
    /// let the consumer define which calls it would like to make
    /// 
    /// Don't start from the feature provider. It might not understand callers needs well.
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            Option<string> name = Option<string>.Some("something");

            //name
            //    .When(s => s.Length > 3).Do(s => Console.WriteLine($"{s} long"))
            //    .WhenSome().Do(s => Console.WriteLine($"{s} short"))
            //    .WhenNone().Do(s => Console.WriteLine("missing"))
            //    .Execute();

            //string label =
            //    name
            //        .When(s => s.Length > 3).MapTo(s => s.Substring(0, 3) + ".")
            //        .WhenSome().MapTo(s => s)
            //        .WhenNone().MapTo("<empty>")
            //        .Map();


            Console.ReadLine();
        }
    }
}

/* 
None of the methods used exist yet, and therefore this code doesn't compile.

But it is indicative of a design approach in which the caller defines the desired interface.
*/

