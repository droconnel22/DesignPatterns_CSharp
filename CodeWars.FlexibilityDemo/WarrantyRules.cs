using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.FlexibilityDemo
{
    //this can be moved outside of class, versus switch instruction
    // you can ALWAYS pull on object out to create loose couple and flexible code.
    class CommonWarrantyRules : IWarrantyMapFactory
    {
        public IReadOnlyDictionary<DeviceStatus, Action<Action>> Create(
            Action<Action> claimMoneyBack, 
            Action<Action> claimNotOperational, 
            Action<Action> claimCircuitry) =>
          new Dictionary<DeviceStatus, Action<Action>>()
          {
              [DeviceStatus.AllFine()] = claimMoneyBack,
              [DeviceStatus.AllFine().NotOperational()] = claimNotOperational,
              [DeviceStatus.AllFine().WithVisibleDamage()] = (action) => { },
              [DeviceStatus.AllFine().NotOperational().WithVisibleDamage()] = claimNotOperational,
              [DeviceStatus.AllFine().CircuitryFailed()] = claimCircuitry,
              [DeviceStatus.AllFine().NotOperational().WithVisibleDamage().CircuitryFailed()] = claimNotOperational

          };

      
    }
}
