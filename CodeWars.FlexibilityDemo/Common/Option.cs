using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.FlexibilityDemo.Common
{
    //Haskel f#, maybe or optional
    // can contains a value or contains nothings - not a wrapper around null.
    // even nothing can be an object

    //!!!!!!!!!!!!ensure that there is never more thane on value.
    //either there or not there

    class Option<T> : IEnumerable<T>, IOption<T>
    {
        private IEnumerable<T>  Content { get; }

        private Option(IEnumerable<T> content)
        {
            this.Content = content;
        }

        public static Option<T> Some(T value)=> new Option<T>(new[] {value});
        public static Option<T> None() => new Option<T>(new T[0]);


        public IEnumerator<T> GetEnumerator() => this.Content.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public IFiltered<T> When(Predicate<T> predicate)
        {
            throw  new NotImplementedException();
            //return
            //    this.Content
            //        .Select(item => this.WhenSome(item, predicate))
            //        .DefaultIfEmpty(new NoneNotMatchedAsSome<T>())
            //        .Single();
        }

        private T WhenSome(T item, Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IFiltered<T>
    {
    }

    internal class NoneNotMatchedAsSome<T>
    {
    }
}
