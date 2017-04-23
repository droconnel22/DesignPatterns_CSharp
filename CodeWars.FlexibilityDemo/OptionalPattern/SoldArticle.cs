using System;
using CodeWars.FlexibilityDemo.Common;

namespace CodeWars.FlexibilityDemo.OptionalPattern
{
    class SoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; private set; }
        public  IWarranty ExpressWarranty { get; private set; }

        private Option<Part> Circuitry { get; set; } = Option<Part>.None();

        private IWarranty FailedCircuitryWarranty { get; set; }

        private  IWarranty NotOperationalWarranty { get; }

        private IWarranty CircuitryWarranty { get; set; }

        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            if(moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));
            if(express == null)
                 throw new ArgumentNullException(nameof(express));
            this.MoneyBackGuarantee = moneyBack;
            this.ExpressWarranty = express;
            this.NotOperationalWarranty = express;
            this.CircuitryWarranty = VoidWarranty.GetInstance;
        }

        public void VisibleDamage()
        {
            this.MoneyBackGuarantee = VoidWarranty.GetInstance;
        }

        public void NotOperational()
        {
            this.MoneyBackGuarantee = VoidWarranty.GetInstance;
            this.ExpressWarranty = this.NotOperationalWarranty;
        }

        public void CircuitryNotOperational(DateTime dectedOn)
        {
            //Action wrapper
            //this.Circuitry.ForEach(circuit =>
            //{
            //    circuit.MarkDefective(dectedOn);
            //    this.CircuitryWarranty = this.FailedCircuitryWarranty;
            //});

            //to list comes from list and gives foreach 
            //converts to strongly typed list of objeted
            this.Circuitry.Do(circuit =>
            {
                circuit.MarkDefective(dectedOn);
                this.CircuitryWarranty = this.FailedCircuitryWarranty;
            });
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            this.Circuitry = Option<Part>.Some(circuitry);
            this.FailedCircuitryWarranty = extendedWarranty;
        }


        /// <summary>
        /// Advice on OO design
        /// Do not use conditional instructions to branch execution
        /// 
        /// Use object substitution to choose on path of the other.
        /// 
        /// Rule of Thumb
        /// 
        /// OBject substitution 
        /// eliminates branching
        /// based on object state.
        /// 
        /// it cannot remove branching over
        /// method arguments.
        /// </summary>
        /// <param name="onValidClaim"></param>
        public void ClaimCircuitryWrranty(Action onValidClaim)
        {
            //warning circuity might be null, resulting in a null reference exception.
            //by putting an optional objects in a collection the methods will only execute
            //if an object exits.
            this.Circuitry.Do(circuitry => 
                this.CircuitryWarranty.Claim(circuitry.DefectDetectedOn, onValidClaim));
        }

    }
}
