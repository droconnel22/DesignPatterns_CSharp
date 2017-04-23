using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Factories.Interfaces;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Models;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Factories.Person
{
    class PersonFactory : IUserFactory
    {
        public IUser CreateUser(string name1, string name2)
        {
            return new Models.Person(name1,name2);
        }

        public IUserIdentity CreateIdentity()
        {
            return new IdentityCard();
        }
    }
}
