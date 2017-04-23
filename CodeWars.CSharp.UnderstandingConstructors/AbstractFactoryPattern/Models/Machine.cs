using System;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Models
{
    public class Machine : IUser
    {
        public Producer Producer { get;  }
        public string Model { get;  }


        public Machine(Producer producer, string model)
        {
            if(producer == null) throw new ArgumentNullException(nameof(producer));
            if(string.IsNullOrEmpty(model)) throw new ArgumentNullException(nameof(model));

            this.Producer = producer;
            this.Model = model;
        }


        public void SetIdentity(IUserIdentity identity)
        {
            throw new NotImplementedException();
        }

        public bool CanAcceptIdentity(IUserIdentity identity)
        {
            throw new NotImplementedException();
        }
    }
}
