using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Factories.Interfaces;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Models;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Factories.Machine
{
    public class MachineFactory  : IUserFactory
    {

        private IDictionary<string, Producer> NameToProducer { get; }

        public MachineFactory(IDictionary<string, Producer> nameOfProducer)
        {
            if(nameOfProducer == null) throw  new ArgumentNullException(nameof(nameOfProducer));
            this.NameToProducer = nameOfProducer;
        }


        //Example of stringly typed 
        public IUser CreateUser(string name1, string name2)
        {
            return  new Models.Machine(this.GetProducer(name1), name2);
        }

        public IUserIdentity CreateIdentity()
        {
            return new MacAddress();
        }


        private Producer GetProducer(string name)
        {
            Producer producer;
            if (!this.NameToProducer.TryGetValue(name, out producer)) 
                throw  new ArgumentException();
            return producer;
        }
    }
}
