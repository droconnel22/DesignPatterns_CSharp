using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.CSharp.ManagingResponsibilities.ObserverDemo
{
    public class Doer
    {
        //goes hand in hand with delegate, replaces Mulitcast infrastructure.
        public event EventHandler<string> AfterDoSomethingWith;

        public MulticastNotifier<Tuple<string, string>> DoMoreWith;

        private string data = string.Empty;
        public Doer()
        {
          
        }

        public void DoSomethingWith(string data)
        {
            this.data = data;
            this.OnAfterDoSomethignWith(this.data);
        }

        public void DoMore(string appendData)
        {
            this.data += appendData;
            this.OnAfterDoMoreWith(this.data, appendData);
        }

        private void OnAfterDoSomethignWith(string data)
        {
            if (this.AfterDoSomethingWith != null)
            {
                //syntatic sugar, makes it seem the even invoked like method.
                this.AfterDoSomethingWith(this,data);
            }
        }

        private void OnAfterDoMoreWith(string completeData, string appendedData)
        {
            if (this.DoMoreWith != null)
            {
                this.DoMoreWith.Notify(this,new Tuple<string, string>(completeData,appendedData));
            }
        }
    }
}