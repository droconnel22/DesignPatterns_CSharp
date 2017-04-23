namespace CodeWars.CodeWars.CSharp.Strings
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;

    // Create a method that accepts an array of names, 
    //and returns an array of each name with its first letter capitalized.
    
    public class Captial_FirstLetter_StringArray
    {
        public string[] CapMe(string[] strings)
        {
            return strings.Select(s => s = char.ToUpper(s.First()).ToString() + s.Substring(1).ToLower()).ToArray();

        }
    }

    //Write a function that takes a single string (word) as argument. 
    //The function must return an ordered list containing 
    //the indexes of all capital letters in the string.

    public class CaptialsToIndexes
    {
        public int[] CountCaptials(string word)
        {
            return word.Where(Char.IsUpper).Select(w => word.IndexOf(w)).ToArray();
        }
    }

    //Sum the scores, truncate worse 3 scores.
    public static class SumSeasonScore
    {
        public static int SumScore(string scores)
        {
            return scores.Split(',')
                .Select(s => Int32.Parse(s))
                .OrderBy(n => n)
                .Take(3)
                .Sum();
        }
    }
}
