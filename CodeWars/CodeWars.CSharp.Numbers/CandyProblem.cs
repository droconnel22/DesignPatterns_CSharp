using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Numbers
{

// We have a bunch of kids and in the list/array 
// and there is shown how much candy each kid has. 
// Because we don't want kids to argue, we want each 
// kid to have the same amount of candies, but we 
// can't take candies from kids.

// Your job is to give all the kids the same amount of candies 
// as the kid with the most candies and then return the total 
// number candies that have been given out. If there are no kids, 
// or 1, return -1. In the first case the most candies are given 
// to second kid, 8. Because of that we will give the first kid 
// 3 the third kid 2 and the fourth kid 4, so all kids will have 8 candies.

// Together we will give out 3 + 2 + 4 = 9 candies, that is why function 
// returns 9. In the last case you do the same u see second kid has 6 
// candies so we need to give first one 5 and that is also the answear

    public static class CandyProblem
    {
        public static int GetMissingCandies(int[] candies)
        {
            // int[] input = {5, 8, 6, 4};
            // int expected = 9;

            int candyGiveOutTotal = 0;

            if (candies.Count() == 1 || !candies.Any())
            {
                return -1;
            }

            foreach (int kitCount in candies)
            {
                candyGiveOutTotal += candies.Max() - kitCount;
            }
            
            return candyGiveOutTotal;
        }
    }
}
