using System;

namespace CodeWars.ObjectOriented.Console.BranchingOverBoolean
{
    class Active : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance) => this;
        public IAccountState Withdraw(Action subtractFromBalance) => this;
        public IAccountState Freeze() => new Frozen(this.OnUnfreeze);
        public IAccountState HolderVerified() => this;
        public IAccountState Close() => this;
    }
}