using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Models
{
    class IdentityCard : IUserIdentity
    {
        public string SSN { get; set; }
    }
}
