using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.FlexibilityDemo
{
    interface IWarrantyMapFactory
    {
        IReadOnlyDictionary<DeviceStatus,Action<Action>> Create(Action<Action> claimMoneyBack, Action<Action> claimNotOperational, Action<Action> claimCircuitry);
    }
}
