using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.AvoidingNulls
{
    //null object
    // an object whiche xposes a certain inferace, but internally it does nothing.
    // used a substitute instead of null.

        //implemented a singleton below
    class VoidWarranty : IWarranty
    {
        
        //null objects should implement singleton pattern
        //singletons have a static instance of themsleves
        //so they control what is returned.
        //and ensure that only one instance is ever created.
        [ThreadStatic]
        private static VoidWarranty instance;

        //singletons have private ctor
        private VoidWarranty() { }

        public static VoidWarranty Instance
        {
            get
            {
                if(instance == null)
                    instance = new VoidWarranty();
                return instance;
            }
        }

        public bool IsValidOn(DateTime date) => false;


        public void Claim(DateTime onDate, Action onValidClaim) {}
    }
}
