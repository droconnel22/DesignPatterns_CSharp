using System;
using System.Collections.Generic;
using CodeWars.FlexibilityDemo.OptionalPattern;

namespace CodeWars.FlexibilityDemo.Common
{
    interface IOption<T>
    {
        IEnumerator<T> GetEnumerator();
        IFiltered<T> When(Predicate<T> predicate);
    }
}