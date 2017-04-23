using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{
   public static class LeetSepak
   {
       private static Dictionary<char, char> leetDictionary = new Dictionary<char, char>
       {
           {'A', '@'},
           {'B', '8'},
           {'C', '('},
           {'D', 'D'},
           {'E', '3'},
           {'F', 'F'},
           {'G', '6'},
           {'H', '#'},
           {'I', '!'},
           {'J', 'J'},
           {'K', 'K'},
           {'L', '1'},
           {'M', 'M'},
           {'N', 'N'},
           {'O', '0'},
           {'P', 'P'},
           {'Q', 'Q'},
           {'R', 'R'},
           {'S', '$'},
           {'T', '7'},
           {'U', 'U'},
           {'V', 'V'},
           {'W', 'W'},
           {'X', 'X'},
           {'Y', 'Y'},
           {'Z', '2'},
           {' ', ' '}
       };


        public static string ToLeetSpeak(string input)
        {
            return input.ToCharArray().Aggregate(string.Empty, (current, c) => current + leetDictionary[c]);
        }
   }
}
