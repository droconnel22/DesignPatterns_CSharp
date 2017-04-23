using System;

namespace CodeWars.ObjectOriented.Console.StatePattern
{
    class AccountSD
    {
        //private bool IsFrozen { get; set; }
        public decimal Balance { get; private set; }
        private IAccountState State { get; set; }

        public AccountSD(Action onUnFreeze)
        {
           this.State = new NotVerified(onUnFreeze);
        }

        public void Deposit(decimal amount)
        {
            this.State = this.State.Deposit(() => { this.Balance += amount; });
        }

        public void Withdraw(decimal amount)
        {
            this.State = this.State.Withdraw(() => { this.Balance -= amount; });
        }

        public void HolderVerified()
        {
            this.State = this.State.HolderVerfied();
        }

        public void Close()
        {
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            this.State = this.State.Freeze();
        }
    }

    // State Design Pattern
    //return the NEXT state
    public interface IAccountState
    {
        IAccountState Deposit(Action adddToBalance); //Callback Pattern
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze();
        IAccountState HolderVerfied();
        IAccountState Close();
    }

    public class Active: IAccountState
    {

        private Action OnUnFreeze { get; }

        public Active(Action OnUnFreeze)
        {
            this.OnUnFreeze = OnUnFreeze;
        }

        public IAccountState Deposit(Action addToBalance) => this; //nothing to do, return current state

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => new Frozen(this.OnUnFreeze);
        public IAccountState HolderVerfied() => this;

        public IAccountState Close() => this;
    }
    
    public class Frozen: IAccountState
    {

        private Action onUnFreeze { get; }

        public Frozen(Action onUnFreeze)
        {
            this.onUnFreeze = onUnFreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            this.onUnFreeze();
            addToBalance();
           return  new Active(this.onUnFreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.onUnFreeze();
            subtractFromBalance();
            return new Active(this.onUnFreeze);
        }

        public IAccountState Freeze() => this; // do nothing
        public IAccountState HolderVerfied() => this;

        public IAccountState Close() => this;
    }

    public class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action OnUnfreeze)
        {
            this.OnUnfreeze = OnUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerfied() => new Active(this.OnUnfreeze);

        public IAccountState Close() => new Closed();

    }

    //Allows no methods. Closed accountw ill remain closed forever.
    public class Closed : IAccountState
    {
        public IAccountState Deposit(Action addToBalance) => this;
        public IAccountState Withdraw(Action subtractFromBalance) => this;
        public IAccountState Freeze() => this;
        public IAccountState HolderVerfied() => this;
        public IAccountState Close() => this;
    }
}
