using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{

    //https://www.youtube.com/watch?v=sn0DWI-JdNA&t=59s
    public static class CoinChallenge
    {
        private static int _count = 0;

        public static int CreateMatrix(int[] array, int N)
        {
            //var matrix =new int[5][];
            CountCoins(N, array);
            return _count;

        }


        public static long MakeChange(int[] coins, int money)
        {
            return makeChange(coins, money, 0, new Dictionary<string, long>());
        }

        private static long makeChange(int[] coins, int money, int index, IDictionary<string,long> memonicMatrix )
        {

            if (money == 0)
            {
                return 1;
            }

            if (index >= coins.Length)
            {
                return 0;
            }

            string key = money + "-" + index;
            if (memonicMatrix.ContainsKey(key))
            {
                return memonicMatrix[key];
            }
            int amountWithCoin = 0;
            long ways = 0;
            while (amountWithCoin <= money)
            {
                int remaining = money - amountWithCoin;
                ways += makeChange(coins, remaining, index + 1, memonicMatrix);
                amountWithCoin += coins[index];
            }


            memonicMatrix.Add(key, ways);
            return ways;
        }

        private static void CountCoins(int N, int[] array)
        {
            Console.WriteLine("N: " + N + " new Array: " + PrintArray(array));
            if (N==0)
            {
                _count++;
            }
            else
            {
                int currentCoin = array[0];
                int currentCoinCount = 0;
                int[] newArray = ClipArray(array, 0);
                var change = N - currentCoin * currentCoinCount;
              
                while (change >= 0 && newArray.Length > 0)
                {
                    Console.WriteLine("Let's add another coin" + " Current Coin "+ currentCoin + " x " + currentCoinCount);
                    Console.WriteLine("We have " + change + " left");
                    CountCoins(change, newArray);
                    currentCoinCount++;
                    change = N - currentCoin * currentCoinCount;
                }
            }
        }

        private static string PrintArray(int[] array) => array.Aggregate(string.Empty, (current, i) => current + (i + " "));

        private static int[] ClipArray(int[] array, int removeIndex)=> array.Where((source, index) => index != removeIndex).ToArray();
    }
}
