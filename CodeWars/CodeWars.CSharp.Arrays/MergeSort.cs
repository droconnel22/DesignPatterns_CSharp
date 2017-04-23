using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Arrays
{
    //Java uses for reference types

    /*
    Divide an array into two halves
    recursively sort each ahlf
    merge two halfs
    http://stackoverflow.com/questions/15835805/mergesort-algorithm-in-c-sharp
    */
    public class MergeSort
    {
        private readonly char[] sentance = new char[] {'e','e','g','m','r','a','c','e','r','t'};


        public static char[] Sort(char[] array)
        {
            char[] auxillaryArray = new char[array.Length];
            Array.Copy(array,auxillaryArray,array.Length);

            int k =0, i = 0;
            int j = array.Length/2 +1;
            while (k < array.Length)
            {
                if (i <= array.Length/2 && j <= array.Length)
                {
                    if (auxillaryArray[i] <= auxillaryArray[j])
                    {
                        array[k] = auxillaryArray[i];
                        i++;
                        k++;
                    }
                    else
                    {
                        array[k] = auxillaryArray[j];
                        j++;
                        k++;
                    }
                }
                else if (i < array.Length/2)
                {
                    //dump i
                    for (int ii = i; ii < array.Length/2; ii++)
                    {
                        array[k] = auxillaryArray[ii];
                        k++;
                    }
                }
                else if (j < array.Length)
                {
                    //dump j
                    for (int jj = j; jj < array.Length; jj++)
                    {
                        array[k] = auxillaryArray[jj];
                        k++;
                    }
                }
            }

            return array;
        }

        public static char[] CorrectSort(char[] array)
        {
            char[] auxillaryArray = new char[array.Length];
            Array.Copy(array, auxillaryArray, array.Length);


            int low = 0;
            int mid = array.Length/2;
            int high = array.Length;
            int i = 0;
            int j = mid +1;

            for (int k = 0; k < array.Length; k++)
            {
                if (i == mid)                                        array[k] = auxillaryArray[j++];
                else if (j == high)                                  array[k] = auxillaryArray[i++];
                else if (auxillaryArray[j] <= auxillaryArray[i])    array[k] = auxillaryArray[j++];
                else                                                array[k] =  auxillaryArray[i++];
            }

            return array;
        }


        private static char[] SmallSort(char[] array, int start, int end)
        {
            
            return array;
        }


        private static void Swap(char[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

    }

    public class MergeSort<T>
        where T : IComparable<T>
    {

        //Exetensions methods cannot be done generically.
        public static T[] Merge(T[] array)
        {
           

            int low = 0;
            int mid = array.Length/2;
            int high = array.Length;
            int i = low;
            int j = mid;


            Console.WriteLine("First Half...");
            Sort(array, low, mid);
            PrintArray(array);
            Console.WriteLine("Second Half...");
            Sort(array, mid, high);
            PrintArray(array);

            T[] aux = new T[array.Length];
            Array.Copy(array, aux, array.Length);
           

            Console.WriteLine("Merging...");
            for (int k = 0; k < high; k++)
            {

                if(i > mid)                                     array[k] = aux[j++];
                else if (j > high)                              array[k] = aux[i++];
                else if (aux[i].CompareTo(aux[j]) > 0)          array[k] = aux[j++];
                else                                            array[k] = aux[i++];
                PrintArray(array);
            }
         
            return array;
        }

        private static void PrintArray(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(" " + item + " ");
            }
            Console.WriteLine("\n");
        }

        //Insertion Sort
        private static T[] Sort(T[] array, int start, int end)
        {
            for (int i = start+1; i < end; i++)
            {
                int j = i - 1;
                while (j >= start)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(array, j, j + 1);
                    }
                    j--;
                }
            }

            return array;
        }

        private static void Swap(T[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

    }
  
}
