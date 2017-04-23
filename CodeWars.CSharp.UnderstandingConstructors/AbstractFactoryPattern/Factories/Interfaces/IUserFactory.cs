using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Factories.Interfaces
{
    public interface IUserFactory
    {
        IUser CreateUser(string name1, string name2);

        IUserIdentity CreateIdentity();
    }
}
