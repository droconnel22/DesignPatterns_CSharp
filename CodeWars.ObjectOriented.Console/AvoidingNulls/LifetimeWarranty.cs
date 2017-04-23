using System;

namespace CodeWars.ObjectOriented.Console.AvoidingNulls
{
    class LifetimeWarranty : IWarranty
    {
        private  DateTime IssuingDate { get; }

        public LifetimeWarranty(DateTime issuingDate)
        {
            this.IssuingDate = issuingDate;
        }


        private bool IsValidOn(DateTime date) =>
            date.Date >= this.IssuingDate;

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if(this.IsValidOn(onDate)) return;
            onValidClaim();
        }
    }
}