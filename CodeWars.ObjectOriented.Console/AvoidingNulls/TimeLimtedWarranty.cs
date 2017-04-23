using System;

namespace CodeWars.ObjectOriented.Console.AvoidingNulls
{

    // Special Case Pattern - this implementation doesnt depend on anything that might appear dynamically
    class TimeLimtedWarranty : IWarranty
    {
        private  DateTime DateIssued { get; }
        private  TimeSpan Duration { get; }

        public TimeLimtedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            this.DateIssued = dateIssued;
            this.Duration = TimeSpan.FromDays(duration.Days);
        }

        //public bool IsValidOn(DateTime date) =>
        //    date.Date >= this.DateIssued && date.Date < this.DateIssued + this.Duration;
        //Now a utility function
        private bool IsValidOn(DateTime date) =>
            date.Date >= this.DateIssued && date.Date < this.DateIssued + this.Duration;

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!this.IsValidOn(onDate)) return;
            onValidClaim();
        }

    }
}
