namespace CodeWars.CodeWars.CSharp.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    /*
     * Write a simple regex to validate a username.

    Allowed characters are:

    -lowercase letters -numbers -underscore

    length should be between 4 and 16 characters.
     * */



    public class ValidateUserName_UsingRegex
    {

        private Regex regex;

        public bool ValidateUserName(string userName)
        {
           return new Regex("^[a-z_0-9]{4,16}$").IsMatch(userName);
              
        }
    }
}
