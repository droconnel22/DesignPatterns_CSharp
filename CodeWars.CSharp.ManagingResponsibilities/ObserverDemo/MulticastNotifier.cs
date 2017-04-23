using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeWars.CSharp.ManagingResponsibilities.ObserverDemo
{
    public class MulticastNotifier<T>
    {
        private IList<IObserver<T>> invocationList;

        //rpviate ctors for '+' operator
        private  MulticastNotifier(IObserver<T> observer)
        {
            this.invocationList = new List<IObserver<T>>() {observer};
        }

        private MulticastNotifier(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            this.invocationList = new List<IObserver<T>>(notifier.invocationList);
            this.invocationList.Add(observer);
        }

        //REmove public ctor as it puts a burder on class implementaion
        //public MulticastNotifier(IEnumerable<IObserver<T>> observers)
        //{
        //    this.invocationList = new List<IObserver<T>>(observers);
        //}


        public void Notify(object sender, T data)
        {
            foreach (var observer in this.invocationList)
            {
                observer.Update(sender, data);
            }
        }

        public static MulticastNotifier<T> operator +(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            if(notifier == null)
                return new MulticastNotifier<T>(observer);
            return new MulticastNotifier<T>(notifier, observer);

        }
    }
}