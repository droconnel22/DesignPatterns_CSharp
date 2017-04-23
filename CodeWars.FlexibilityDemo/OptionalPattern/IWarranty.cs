using System;

namespace CodeWars.FlexibilityDemo.OptionalPattern
{
    interface IWarranty
    {
        void Claim(IWarranty defectDetectedOn, Action onValidClaim);
        void Claim(DateTime now, Action onValidClaim);
    }
}