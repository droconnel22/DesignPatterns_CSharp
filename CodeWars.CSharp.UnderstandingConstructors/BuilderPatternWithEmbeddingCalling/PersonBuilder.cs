using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.CSharp.UnderstandingConstructors.AbstractFactoryPattern.Models;

namespace CodeWars.CSharp.UnderstandingConstructors.BuilderPatternWithEmbeddingCalling
{
   public class PersonBuilder
   {
       private INonEmptyStringState FirstNameState { get; set; } = new UninitialzedString();

        private INonEmptyStringState LastNameState { get; set; } = new UninitialzedString();


       public void SetFirstName(string firstName) => this.FirstNameState = this.FirstNameState.Set(firstName);

        public void SetLastName(string lastName) => this.LastNameState = this.LastNameState.Set(lastName);

        public Person Build() => new Person(this.FirstNameState.Get(), this.LastNameState.Get());


    }
}
