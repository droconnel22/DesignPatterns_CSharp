using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.FlexibilityDemo.Common;
using CodeWars.FlexibilityDemo.OptionalPattern;

namespace CodeWars.FlexibilityDemo
{
    class FlexibleSoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; }
        private IWarranty NotOperationalWarranty { get; }
        private IWarranty CircuitryWarranty { get; set; }

        private IOption<Part> Circuitry { get; set; } = Option<Part>.None();

        private DeviceStatus OperationalStatus { get; set; }

        //Triple Dispatch - Dynamic Dispatch
        //Decision might be based on dynamic conditions
        //1. Using the map status to discover the actions,we dont know in advance what will be the resul tof the map
        //2. When we get the result, we still do not know what it is, it is an action delegate. THhen a polymorphic call on target
        //3. Possible call on action is again polymorphic.
        //This class deosnt know outcoimes of calls it makes.
        //doesnt have to change when target is change.\
        //Sold article contains no logic to treat warranties
        //keeps warranties, states and rules.
        //Changing class test intivites regression
        //we prefer to adding new types instead

        private IReadOnlyDictionary<DeviceStatus,Action<Action>>  WarrantyMap { get; }

        //remember to start with a proof of concept - piece of code which works correctly.
        //then introduce new types to simplify code.
        //Func<T> delegaes dont have arugments names, only types which makes them indistguishable from one another.
        public FlexibleSoldArticle(IWarranty moneyBack, IWarranty express,IWarrantyMapFactory rulesFactory )
        {
            if (moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));
            if (express == null)
                throw new ArgumentNullException(nameof(express));
            this.MoneyBackGuarantee = moneyBack;
            this.NotOperationalWarranty = express;
            this.CircuitryWarranty = VoidWarranty.GetInstance;
            //Externalized the rules that apply to warranty claiming processes.
            this.WarrantyMap = rulesFactory.Create(this.ClaimMoneyBack, this.ClaimNotOperationalWarranty,this.ClaimCircuitryWarranty);
        }
        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            this.Circuitry = Option<Part>.Some(circuitry);
            this.CircuitryWarranty = extendedWarranty;
            this.OperationalStatus = DeviceStatus.AllFine(); //gateway to accessing the class.
         
        }

      
        private void ClaimCircuitryWarranty(Action obj)
        {
            throw new NotImplementedException();
        }

        private void ClaimNotOperationalWarranty(Action obj)
        {
            throw new NotImplementedException();
        }

        private void ClaimMoneyBack(Action obj)
        {
            throw new NotImplementedException();
        }

        public void CircuitryNotOperational(DateTime dectedOn)
        {
            this.OperationalStatus = this.OperationalStatus.CircuitryFailed();
        }

        public void VisibleDamage()
        {
            this.OperationalStatus = this.OperationalStatus.WithVisibleDamage();
        }

        public void NotOperational()
        {

            this.OperationalStatus = this.OperationalStatus.NotOperational();
        }

        public void Repaired()
        {
            this.OperationalStatus = this.OperationalStatus.Repaired();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            //switch (this.OperationalStatus)
            //{
            //     case DeviceStatus.AllFine:
            //            this.MoneyBackGuarantee.Claim(DateTime.Now, onValidClaim);
            //            break;
            //    case DeviceStatus.NotOperational:
            //        this.NotOperationalWarranty.Claim(DateTime.Now, onValidClaim);
            //            break;
            //    case DeviceStatus.CircuitryFailed:
            //        // logic here
            //        break;
            //}

            this.WarrantyMap[this.OperationalStatus].Invoke(onValidClaim);

        }

       
      
    }
}
