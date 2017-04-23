using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Arrays
{
    public static class Shifted_Array
    {
        
        public static int[] AddingShifted(int[][] arrayOfArrays, int shift)
        {
            var resultList = new List<int>();
            for (int i = 0; i < arrayOfArrays.Length; i++)
            {
                System.Console.WriteLine(i);
                for (int j = 0; j < arrayOfArrays[i].Length; j++)
                {
                    if (j < shift || i + 1 > arrayOfArrays.Length)
                    {
                        resultList.Add(arrayOfArrays[i][j]);
                    }
                    else if (j + shift >= arrayOfArrays[i + 1].Length)
                    {
                        resultList.Add(arrayOfArrays[i][j] + arrayOfArrays[i + 1][j]);
                    }
                    else
                    {
                        resultList.Add(arrayOfArrays[i][j] + arrayOfArrays[i + 1][j + shift]);
                    }
                }
            }


            foreach (var item in resultList)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine("\n--------------\n");
            return resultList.ToArray();
        }
    }
}
