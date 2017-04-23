using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.UnderstandingConstructors.BreathingLifeBackIntoFactoriesWithLambdas
{
    abstract class  PersonalManager
    {

        public abstract IBreatheUser CreateUser();

        public void Notify(string message)
        {
            this.Enqueue(this.GetPrimaryContact(), message);
        }

        private IContactInfo GetPrimaryContact()
        {
            return null;
        }

        private void Enqueue(IContactInfo contact, string message)
        {
            Console.WriteLine($"Sending {message} to {contact}");
        }
    }
}
