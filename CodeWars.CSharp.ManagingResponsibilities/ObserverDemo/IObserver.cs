namespace CodeWars.CSharp.ManagingResponsibilities.ObserverDemo
{
    public interface IObserver<T>
    {
        void Update(object sender, T data);
    }
}