using System;

namespace CodeWars.CSharp.ManagingResponsibilities.ObserverDemo
{
    public class NotificationSink<T> : IObserver<T>
    {
        private Action<object, T> action;

        public NotificationSink(Action<object,T> action)
        {
            this.action = action;
        }

        public void Update(object sender, T data) => this.action(sender, data);
    }
}