using System;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Models
{
    public class Person : IUser
    {
        public string Surname { get; }
        public string Name { get; }
        
        public Person(string name, string surname)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(surname)) throw new ArgumentNullException(nameof(surname));

            this.Name = name;
            this.Surname = surname;
        }

        public void SetIdentity(IUserIdentity identity) { }
        public bool CanAcceptIdentity(IUserIdentity identity) => identity is IdentityCard;
        
        public override string ToString() => $"{this.Name} {this.Surname}";
    }
}