/*******************************************
* PasswordValidator
* By Jamie Youngjae Yoo
* Description : 
* C# program that will check a password entered by the user.
* The password must be compliant with the following rules
    • It must be a minimum of 8 characters in length.
    • There must be at least one uppercase letter.
    • There must be at least one lowercase letter.
    • There must be at least one symbol character.
    • There must not be any space or tab characters in the password.
    • There must be at least two numbers in the password and they must be different.
* If a password does not meet any of the specifications, an error message will show which conditions have not been met.
* ******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            char chRepeat; // user's input to repeat the program
            bool bRepeat;  // check if user entered 'y' or 'n' to repeat the program

            // repeat if while condition is true
            do
            {
                // variables to hold count of char attributes
                int iCharCount = 0, iNumCount = 0, iUpper = 0, iLower = 0, iSymbol = 0, iWhiteSpace = 0;
                string stInput, stErrMsg = "";     // user's input for password, error msg 
                bool bValid = true;            // validation check for the password specifications
                string stDigits = "";           // make a new string with only digits from user's input

                Console.Write("Enter a Password: ");
                stInput = Console.ReadLine();

                // check and validate a password entered by the user
                foreach (char ch in stInput)
                {
                    // count number of password's character
                    iCharCount++;

                    // count uppercase letters
                    if (char.IsUpper(ch))
                    {
                        iUpper++;
                    }
                    // count lowercase letter
                    if (char.IsLower(ch))
                    {
                        iLower++;
                    }
                    // count symbols and punctuations
                    if (char.IsSymbol(ch) || char.IsPunctuation(ch))
                    {
                        iSymbol++;
                    }
                    // count spaces
                    if (char.IsWhiteSpace(ch))
                    {
                        iWhiteSpace++;
                    }
                    // count digit numbers
                    if (char.IsNumber(ch))
                    {
                        iNumCount++;
                        // store digits to string, if digit number was found
                        stDigits += (char)((int)ch);
                    }
                }

                // check the ovelapped digits
                for (int i = 0; i < stDigits.Length; i++)
                {
                    for (int j = i + 1; j < stDigits.Length; j++)
                    {
                        if (stDigits[i] == stDigits[j])
                        {
                            bValid = false;
                            // add error message to string
                            stErrMsg += "Password can't have same digits\n";
                            break;
                        }
                    }
                }

                // display an error message if user entered less than 8 characters
                if (iCharCount < 8)
                {
                    stErrMsg = "Password too short, must be 8 characters or more\n";
                    bValid = false;
                }
                // display an error message if user entered less than 1 uppercase letter
                if (iUpper < 1)
                {
                    stErrMsg += "Password must have a Uppercase character\n";
                    bValid = false;
                }
                // display an error message if user entered less than 1 lowercase letter
                if (iLower < 1)
                {
                    stErrMsg += "Password must have a Lowercase character\n";
                    bValid = false;
                }
                // display an error message if user entered less than 1 symbol chatacters
                if (iSymbol < 1)
                {
                    stErrMsg += "Password must have a Symbol character\n";
                    bValid = false;
                }
                // display an error message if user entered space
                if (iWhiteSpace > 0)
                {
                    stErrMsg += "Password must not contains Whitespace or Tab\n";
                    bValid = false;
                }
                // display an error message if user entered less than 2 different digit numbers
                if (iNumCount < 2)
                {
                    stErrMsg += "Password must contain 2 or more digits\n";
                    bValid = false;
                }

                // display an error message if the password is not validate
                if (!bValid)
                {
                    Console.WriteLine(stErrMsg);
                }
                // display "acceptable" message if the password meet all of the specifications
                else
                {
                    Console.WriteLine($"The password {stInput} is acceptable\n");
                }

                Console.WriteLine($"There are {iCharCount} characters, {iWhiteSpace} Spaces, {iSymbol} symbols, " +
                    $"{iUpper} Uppercases, {iLower} Lowercases, {iNumCount} digits\n");

                // ask if user want to repeat the program
                Console.WriteLine("Do you wish to try again? (y/n)");
                bRepeat = char.TryParse(Console.ReadLine(), out chRepeat);

                // check and ask to user to select either 'y' or 'n'
                while (!bRepeat || (chRepeat != 'y' && chRepeat != 'n'))
                {
                    Console.WriteLine("\nPlease enter 'y' to try again or 'n' to exit");
                    Console.WriteLine("Do you wish to try again? (y/n)");
                    bRepeat = char.TryParse(Console.ReadLine(), out chRepeat);
                }

                Console.WriteLine("\n");

            // repeat the program if user entered 'y'
            } while (chRepeat.ToString().ToLower() == "y");
        }
    }
}
