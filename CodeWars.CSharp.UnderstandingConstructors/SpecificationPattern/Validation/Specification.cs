using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.UnderstandingConstructors.SpecificationPattern.Validation
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T obj);
    }
}
