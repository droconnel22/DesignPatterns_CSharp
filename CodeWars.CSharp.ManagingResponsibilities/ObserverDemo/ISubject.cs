namespace CodeWars.CSharp.ManagingResponsibilities.ObserverDemo
{
    public interface ISubject<T>
    {
        void AfterDoSomethingWith(string data);
        void AfterDoMore(string completeData, string appendData);
        void Attach(IObserver<T> observer);
        void Detach(IObserver<T> observer);

    }
}
