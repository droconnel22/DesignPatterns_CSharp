using System;

namespace CodeWars.CSharp.ManagingResponsibilities.ObserverDemo
{
    //public class Logger :ISubject
    //{
    //    public void AfterDoSomethingWith(ISubject sender, string data) => Console.WriteLine("Writing Down {0}", data.ToUpper());

    //    public void AfterDoMore(ISubject sender, string completeData, string appendData)
    //        => Console.WriteLine("Writing down appended {0}", appendData.ToUpper());
    //}

    public class Logger
    {

        public readonly IObserver<string> AfterDoSomethingWithEventer;

        public readonly IObserver<Tuple<string, string>> AfterDoMore;

        public Logger()
        {
            this.AfterDoMore = 
                new NotificationSink<Tuple<string,string>>(this.AfterDoMoreHanlder);
        }



        public void AfterDoSomethingWith(object sender, string data) => Console.WriteLine("Writing Down {0}", data.ToUpper());

        public void AfterDoMoreHanlder(object sender, Tuple<string,string> data) =>
            Console.WriteLine("Writing down appended {0}", data.Item2.ToUpper());
    }
}