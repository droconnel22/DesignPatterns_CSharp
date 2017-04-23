using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces
{
     public interface IUser : ITicketHolder
     {
         void SetIdentity(IUserIdentity identity);

         bool CanAcceptIdentity(IUserIdentity identity);
     }
}
