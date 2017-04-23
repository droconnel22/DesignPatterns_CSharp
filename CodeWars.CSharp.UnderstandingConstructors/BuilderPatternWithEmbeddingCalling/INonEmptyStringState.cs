namespace CodeWars.CSharp.UnderstandingConstructors.BuilderPatternWithEmbeddingCalling
{
    internal interface INonEmptyStringState
    {
        INonEmptyStringState Set(string firstName);

        string Get();
    }
}