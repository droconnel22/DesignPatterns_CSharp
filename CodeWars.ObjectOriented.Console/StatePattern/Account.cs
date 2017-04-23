using System;

namespace CodeWars.ObjectOriented.Console.StatePattern
{
    public class Account
    {
        private bool IsFrozen { get; set; }
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        //Custom Callback Function
        private Action onUnFreeze { get; }

        public Account(Action onUnFreeze)
        {
            this.onUnFreeze = onUnFreeze;
        }

        public void Deposit(decimal amount)
        {
            if(this.IsClosed) return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.onUnFreeze();
            }

            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified) return;
            if(this.IsClosed) return;

            //withdraw money
            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed) return;
            if (!this.IsVerified) return;
            this.IsFrozen = true;
        }

    
    }
}
