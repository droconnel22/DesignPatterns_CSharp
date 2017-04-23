using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.BranchingOverBoolean
{
    /// <summary>
    /// MOney can be deposited at any time.
    /// 
    /// Money can be withdrawn only after
    /// the account owners identity has been 
    /// verified.
    /// 
    /// Account cholder can close the account at any time
    /// 
    /// Closed account doesnt allow depoist and withdraw
    /// 
    /// Account will be unfrozen automatically on deposit or withdraw
    /// 
    /// Unfreezing the account triggers a custom action
    /// </summary> 

    class Account
    {
        public decimal Balance { get; private set; }

        private bool IsVerifeid { get; set; }
        private bool IsClosed { get; set; }

        private IAccountState AccountState { get; set; }
        public Account(Action onUnFreeze)
        {
           this.AccountState = new Active(onUnFreeze);
        }

        public void Deposit(decimal amount)
        {
            if(this.IsClosed) return;
            this.AccountState = this.AccountState.Deposit(() => this.Balance += amount);
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerifeid) return;
            if (this.IsClosed) return;
            this.AccountState = this.AccountState.Withdraw(() => this.Balance -= amount);
        }
     

        public void HolderVerified()
        {
            this.IsVerifeid = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if(this.IsClosed) return;
            if(!this.IsVerifeid) return;
            this.AccountState = this.AccountState.Freeze();
        }
    }
}
