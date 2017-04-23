using System;

namespace CodeWars.ObjectOriented.Console.AvoidingNulls
{
    class SoldArticle
    {
        //Post Conditions
        public IWarranty MoneyBackGuarantee { get; private set; }
        public IWarranty ExpressTimeLimtedWarranty { get; private set; }

        private IWarranty NotOperationalWarranty { get; }

        public SoldArticle(IWarranty moneyBack, IWarranty expressTimeLimted)
        {
            //Constructor Preconditions
            if(moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));

            if(expressTimeLimted == null)
                throw  new ArgumentNullException(nameof(expressTimeLimted));

            this.MoneyBackGuarantee = moneyBack;
            this.ExpressTimeLimtedWarranty = VoidWarranty.Instance;
            this.NotOperationalWarranty = expressTimeLimted;
        }

        public void VisibleDamage() =>
            this.MoneyBackGuarantee = VoidWarranty.Instance;

        public void NotOperational()
        {
            this.MoneyBackGuarantee = VoidWarranty.Instance;
            this.ExpressTimeLimtedWarranty = this.NotOperationalWarranty;
        }
           
       

    }
}

/// avoid branching over boolean conditions calculated from the objects state
/// 
/// make polymorphic calls onthe state object instead