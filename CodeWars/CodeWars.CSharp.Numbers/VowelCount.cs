using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Numbers
{
    public static class VowelCount
    {

        private static List<char> vowels = new List<char>{'a','e','i','o','u'}; 

        //Reunt the number or count of vowels in the give string.

        public static int GetVowelCount(string input)
        {
            return input.Count(letter => vowels.Contains(letter));
        }
    }
}
