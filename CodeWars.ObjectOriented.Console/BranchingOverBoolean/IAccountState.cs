using System;

namespace CodeWars.ObjectOriented.Console.BranchingOverBoolean
{
    /// <summary>
    /// State Pattern
    /// Object of the state class
    /// represents one state.
    /// 
    /// Change the object when you 
    /// want to change the state.
    /// </summary>

    interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}