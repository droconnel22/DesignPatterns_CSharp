using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{

    /// <summary>
    ///  ["Telescopes", "Glasses", "Eyes", "Monocles"]
    /// </summary>
    public static class SortByStringLength
    {
        public static string[] SortByLength(string[] array)
        {
           return array.OrderBy(s => s.Length).ToArray();
        }
    }


}
