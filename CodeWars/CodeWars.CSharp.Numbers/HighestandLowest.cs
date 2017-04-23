using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Numbers
{
    public class HighestandLowest
    {
        public string HighAndLow(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
            {
                return string.Empty;
            }

           var result = numbers.Split(' ').Select(x => Convert.ToInt32(x)); 
            return result.Max() + " " + result.Min();
        }

        public string HighAndLowAlternative(string numbers)
        {
            var parsedList = numbers.Split(' ').Select(int.Parse);
            return string.Format("{0} {1}", parsedList.Max(), parsedList.Min());         
        }
    }
}
