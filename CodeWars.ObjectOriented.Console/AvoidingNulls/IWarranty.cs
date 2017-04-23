using System;

namespace CodeWars.ObjectOriented.Console.AvoidingNulls
{
    //Common for both valid and invalid object
    // Advice Class that implements an interface should have a meaningful name.
    // Avoid just repeating the interface name.
    //Created objects based on branching, autonomous objects

    /// <summary>
    /// The trap of OO design
    /// don't design interfaces which are just making it possible
    /// for the caller to implment features
    /// 
    /// Design interfaces which are forcing their
    /// implementing classes to provide features!
    /// </summary>

    interface IWarranty
    {
        //replaced by claim
        //bool IsValidOn(DateTime date);
        //This is ths OO way
        void Claim(DateTime onDate, Action onValidClaim);
    }
}