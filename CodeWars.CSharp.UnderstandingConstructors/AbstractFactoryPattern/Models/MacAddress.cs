using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Interfaces;

namespace CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Models
{
    class MacAddress : IUserIdentity
    {
         public string RawAddress { get; set; }
    }
}