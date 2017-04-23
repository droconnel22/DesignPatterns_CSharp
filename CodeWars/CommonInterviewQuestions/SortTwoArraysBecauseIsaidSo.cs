using System;

namespace CodeWars.CommonInterviewQuestions
{
    // Write a function to sort 2 arrays of numbers (without using existing libraries).

    public class SortTwoArraysBecauseIsaidSo
    {
        public static int[] SortThese(int[] arrayA, int[] arrayB) =>  
            arrayA
            .Sort()
            .CombineAndSort(arrayB.Sort());
    }

    public static class ArrayExtensions
    {
        public static int[] Sort(this int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                while (j >= 0)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                    j--;
                }
            }

            return array;
        }

        private static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = array[a];
        }

        public static int[] CombineAndSort(this int[] arrayA, int[] arrayB)
        {
            var arrayC = new int[arrayA.Length + arrayB.Length];
            return arrayC.Sort();
        }
    }
}
