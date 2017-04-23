using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Numbers
{
   public static class HelpYourGranny
    {

        public static int tour(string[] arrFriends, string[][] ftwns, Hashtable h)
        {
            double totalDistance = 0.0;
            for (int i = 0; i < arrFriends.Length; i++)
            {

                string point = string.Empty;
                foreach (var townPair in ftwns)
                {
                    if (townPair[0] == arrFriends[i])
                    {
                        point = townPair[1];
                    }
                }

                if (i == 0)
                {
                    totalDistance += (double)h[point];
                }
                else if (i +1== arrFriends.Length)
                {
                    totalDistance += (double) h[ftwns[i-1][1]];
                }
                else
                {
                    totalDistance += Compute((double)h[ftwns[i][1]], (double)h[ftwns[i - 1][1]]); 
                }
            }
            // your code
            return (int)totalDistance;
        }

       private static double Compute(double c, double a) => Math.Sqrt((Math.Pow(c,2) - Math.Pow(a, 2)));
    }
}



/*
https://www.dotnetperls.com/hashtable
 foreach (DictionaryEntry entry in hashtable)
        {
            Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
        }

    */
