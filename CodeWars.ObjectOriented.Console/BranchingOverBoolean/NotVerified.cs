using System;

namespace CodeWars.ObjectOriented.Console.BranchingOverBoolean
{
    class NotVerified : IAccountState
    {

        private Action onUnfreeze { get; }

        public NotVerified(Action OnUnFreeze)
        {
            this.onUnfreeze = OnUnFreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified()
        {
           return new Active(this.onUnfreeze);
        }

        public IAccountState Close() => new Closed();
    }
}