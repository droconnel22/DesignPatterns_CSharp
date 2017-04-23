using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.ManagingResponsibilities.ObserverDemo
{
    class Program
    {
        /*
        Observer design patter out of the box.
        observer design pattern is supported by the C# language.
        keywords delegate and event had to be added to the language to support it.
        */
        public static void Main(string[] args)
        {
            Doer doer = new Doer();

            UserInterface userInterface = new UserInterface();
            Logger logger = new Logger();

            doer.AfterDoSomethingWith += userInterface.AfterDoSomethingWith;
            doer.AfterDoSomethingWith += logger.AfterDoSomethingWith;

            doer.DoMoreWith += logger.AfterDoMore;

            doer.DoSomethingWith("my data");
            doer.DoMore("Tail");
            Console.ReadLine();
        }
    }
}
