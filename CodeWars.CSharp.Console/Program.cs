using System ;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.Console
{
    class Program
    {
        

        private static IDictionary<string,Func<int,int,bool>> _predicates;

        private static IDictionary<Predicate<int>, string> _thingys;

        public static Delegate MyDelagate;

        static void Main(string[] args)
        {
            _predicates = new Dictionary<string, Func<int, int, bool>>();

            _predicates.Add("GreaterThan", (v, f) => v > f);
            _predicates.Add("LessThan", (v, f) => v < f);
            _predicates.Add("Equals", (v, f) => v == f);


            _thingys = new Dictionary<Predicate<int>, string>();
            _thingys.Add(isThisNumberCorrect, "shit");

            bool result = AnotherCustomPredicate(5);

            var helloBook = new ProcessBookDelegate(Hello);

            helloBook("shit");


            var customers = new List<string>();

            customers.Where(delegate(string c) { return c == "me"; });
            customers.Where(c => c == "me");
            customers.Where(c => DoesThisEqualMe(c));
            customers.Where(c => DoesThisFuncMe(c));

            

            string mystring = "banana";
            mystring.Shout();

            Action<double> print = System.Console.Write;

            print(4.0);

        }

        private static Predicate<int> isThisNumberCorrect = new Predicate<int>(CheckIfNumberIsCorrect);

        private static bool CheckIfNumberIsCorrect(int value)
        {
            return value == 1;
        }

        private static Predicate<int> AnotherCustomPredicate = i => i == 1;

        //Predicate is a functor that automatically returns a bool
        private static Predicate<string> DoesThisEqualMe => c => c == "me";

        //Functor or function pointer takes in arguments, where the last argument is the out. An out bool mirrors a predicate
        private static Func<string, bool> DoesThisFuncMe => x => x == "me";

        private delegate void ProcessBookDelegate(string s);

        public static void Hello(string s)
        {
            System.Console.WriteLine(" Hello, {0}!",s);
        }

        //Anonymous function is better then tuples (too cumbersome)
    }

    //Extend STring Methods (must be part of a static class and be a static method
    static class StringExtensions
    {
        public static string Shout(this string s)
        {
            return s.ToUpper() + "!!!!";
        }
    }
}

