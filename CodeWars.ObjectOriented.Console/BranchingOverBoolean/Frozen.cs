using System;

namespace CodeWars.ObjectOriented.Console.BranchingOverBoolean
{
    class Frozen : IAccountState
    {

        private Action OnUnFreeze { get; }

        public Frozen(Action onUnFreeze)
        {
            this.OnUnFreeze = onUnFreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnFreeze();
            return new Active(addToBalance);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnFreeze();
            return new Active(subtractFromBalance);
        }

        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;

        public IAccountState Close() => this;
    }
}