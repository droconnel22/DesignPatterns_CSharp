using System;

namespace CodeWars.CSharp.UnderstandingConstructors.BuilderPatternWithEmbeddingCalling
{
    internal class UninitialzedString : INonEmptyStringState
    {
        public INonEmptyStringState Set(string firstName)
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            throw new NotImplementedException();
        }
    }
}