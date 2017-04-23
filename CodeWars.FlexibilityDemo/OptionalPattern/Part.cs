using System;

namespace CodeWars.FlexibilityDemo.OptionalPattern
{
    class Part
    {
        public DateTime InstallmentDate { get; }
        public IWarranty DefectDetectedOn { get; set; }

        public Part(DateTime installmentDate)
        {
            this.InstallmentDate = installmentDate;
        }

        public void MarkDefective(DateTime dectectedOn)
        {
           
        }
    }
}