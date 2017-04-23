using System;

namespace CodeWars.CodeWars.CSharp.Misc
{
    public static class AppendAndDelete
    {
        //https://www.hackerrank.com/challenges/append-and-delete?h_r=next-challenge&h_v=zen
        public static string Main(string s, string t, int k)
        {
            int countK = 0;
            var s_Array = s.ToCharArray();
            var t_Array = t.ToCharArray();

            //compare T to S, edit S, Find Common, as soon a change, delete rest.  
            for (int i = 0; i < t_Array.Length; i++)
            {

                if (i > s_Array.Length - 1)
                {
                    break;
                }

                if (t_Array[i] != s_Array[i])
                {
                    countK = s_Array.Length - i;
                    s_Array = s.Substring(0, i).ToCharArray();
                    break;
                }
            }

            string new_s = string.Empty;
            if (countK > 0)
            {
                //Console.WriteLine("S: " + new string(s_Array) + " Count: " + countK);              
                new_s = new string(s_Array) + t.Substring(s_Array.Length);
                countK += t_Array.Length - s_Array.Length;
                if (countK < k)
                {
                    countK = k;
                }

                //  Console.WriteLine("S: " + new_s + " Count: " + countK);                        
            }
            else if (countK == 0)
            {
                //so our string are equal. Can we game the system by bring s to 0 and running the clock down.
                //we dont have to necessary transform anything merely game it.


                new_s = t;
                int transform = s.Length * 2;
                if (transform <= countK)
                {
                    countK += transform + (countK - transform);
                }
                else
                {
                    countK = k;
                }



            }

            // Console.WriteLine("K: " + countK);
            if (countK == k && String.Equals(new_s, t))
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public static void FUCKME()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            int k = Convert.ToInt32(Console.ReadLine());

            int i = 0;
            while (true)
            {
                if ((i == s.Length || i == t.Length) || (s[i] != t[i]))
                    break;
                i++;
            }

            int n = (s.Length - i) + (t.Length - i);
            if ((s.Length + t.Length) < k || n == k || ((k - n) > 0 && (k - n) % 2 == 0))
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
