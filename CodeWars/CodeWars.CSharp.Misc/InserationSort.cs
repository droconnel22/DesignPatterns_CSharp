using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{
    public static class InserationSort
    {

        public static int[] Sort(int[] array)
        {
            try
            {
                for (int i = 1; i < array.Length; i++)
                {
                    int j = i - 1;
                    while (j >= 0)
                    {
                        if (array[j] > array[j+1])
                        {
                            Swap(array, i, j);
                        }
                        j--;
                    }
                }

            }catch (Exception exception)
            {
                var errorArray = new int[5];
                return errorArray;
            }

            return array;
            
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[j + 1];
            array[j + 1] = array[j];
            array[j] = temp;
        }
    }
}
