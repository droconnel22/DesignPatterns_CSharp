using System.Collections.Generic;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public class VacationSpecification
    {

        private readonly IEnumerable<IVacationPart> parts;

        public VacationSpecification(IEnumerable<IVacationPart> parts)
        {
            this.parts = parts;
        }
    }
}