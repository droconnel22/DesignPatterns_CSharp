using System;


class Solution
{
    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        var contractTrie = new Trie();
        for (int nItr = 0; nItr < n; nItr++)
        {
            string[] opContact = Console.ReadLine().Split(' ');

            string op = opContact[0];

            string contact = opContact[1];
            contractTrie.Execute(op, contact);
        }
    }
}
