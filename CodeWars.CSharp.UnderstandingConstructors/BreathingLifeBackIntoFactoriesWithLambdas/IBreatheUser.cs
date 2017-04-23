using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;

namespace CodeWars.CSharp.UnderstandingConstructors.BreathingLifeBackIntoFactoriesWithLambdas
{
    interface IBreatheUser
    {
        IContactInfo PrimaryContact { get; }
        void SetIdenity(IUserIdentity identity);
        void Add(IContactInfo contact);
        void SetPrimaryContact(IContactInfo contact);
    }

    internal interface IContactInfo
    {
    }
}
