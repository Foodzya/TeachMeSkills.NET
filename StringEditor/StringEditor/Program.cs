using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringEditor
{

    // Input - WHITE
    // Warnings/Errors - RED
    // Instructions - BLUE
    // Appearance - GREEN
    class Program
    {
        static void Main(string[] args)
        {

            // Defining variable that contain options that user can perform.
            string menu;
            menu = 
                "\n\t1) Find words containing the maximum number of digits" +
                "\n\t2) Find the longest word and determine how many times it appears in the text;" +
                "\n\t3) Replace digits 0-9 with the word \"zero\", \"one\", \"two\", ..., \"nine\";" +
                "\n\t4) Display interrogative sentences first, then exclamation sentences;" +
                "\n\t5) Display sentences which don't contain commas;" +
                "\n\t6) Find words starting and ending with the same letter.";

            Console.ForegroundColor = ConsoleColor.White;

            // Welcoming message.
            Console.WriteLine("\t\t—————————————————————————");
            Console.WriteLine("\t\tWelcome to String Editor!");
            Console.WriteLine("\t\t—————————————————————————");

            bool newInput = true;
            while (newInput)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                
                // Defining variable which contain user text input.
                Console.WriteLine("\nPlease write down text that you want to edit:");
                Console.ForegroundColor = ConsoleColor.White;
                string usersInput = Console.ReadLine();

                // Checking for Cyrillic symbols in the text.
                while (Regex.IsMatch(usersInput, @"\p{IsCyrillic}"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\aYour text is containing Cyrillic symbols. Please repeat your input using Latin symbols and punctuation marks:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usersInput = Console.ReadLine();
                }

                // Variable responding for choosing new operation on the text.
                bool repeatOperation = true;

                while (repeatOperation == true)
                {
                    // Displaying menu of options.
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{menu} \n\nPlease choose the option you want to perform on your text: ");

                    // Defining variable containing the number of operation entered by the user.
                    int usersChoice;

                    // Checking for input correctness.
                    Console.ForegroundColor = ConsoleColor.White;
                    while (!int.TryParse(Console.ReadLine(), out usersChoice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\aSomething goes wrong. Please enter the number of operation (1-6): ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    // Performing an action according to the user's choice.
                    switch (usersChoice)
                    {
                        case 1:

                            // Defining a regular expression to find numbers in a text
                            string pattern = @"\d";

                            // Checks text for digits in it.
                            if (Regex.IsMatch(usersInput, pattern))
                            {
                                // Splitting text into an array of words using delimiters.
                                string[] textByWords = usersInput.Split(new string[] { " ", ",", "\t", ".", "!", "?", "\t", "\n", ";", ":", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                                string allDigits = "0123456789";

                                // Defining variable containing number of all words in the text.
                                int numOfWords = textByWords.Length;

                                // An array that will contain words with digits.
                                int[] numOfDigitsInWord = new int[numOfWords];

                                // Loop that checks each word for digits.
                                for (int i = 0; i < numOfWords; i++)
                                {
                                    for (int j = 0; j < textByWords[i].Length; j++)
                                        if (allDigits.IndexOf(textByWords[i][j]) >= 0)
                                            numOfDigitsInWord[i]++;
                                }

                                // Defining variable containing maximum number of digits.
                                int maxNumOfDigits = 0;

                                // Loop for comparing words on the maximum number of digits.
                                for (int i = 0; i < numOfWords; i++)
                                {
                                    if (numOfDigitsInWord[i] > maxNumOfDigits)
                                    {
                                        maxNumOfDigits = numOfDigitsInWord[i];
                                    }
                                }

                                // Displaying words that contain maximum number of digits.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Clear();
                                Console.Write("Word(-s) that contain maximum number of digits is (are): ");
                                for (int i = 0; i < numOfWords; ++i)
                                {
                                    if (numOfDigitsInWord[i] == maxNumOfDigits)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write($"{textByWords[i]}, ");
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("There is no digits in your text.");
                            }
                            break;


                        case 2:
                            // Splitting a string into an array of strings.
                            string[] textByArrays = usersInput.Split(new string[] { " ", ",", "\t", ".", "!", "?", "\t", "\n", ";", ":", "(", ")", "-", "—" }, StringSplitOptions.RemoveEmptyEntries);

                            // Defining variable for containing temporarily longest word. 
                            string maxLength = "";

                            // Loop for finding the longest word by comparison with each other.
                            for (int i = 0; i < textByArrays.Length; i++)
                            {
                                if (maxLength.Length < textByArrays[i].Length)
                                {
                                    maxLength = textByArrays[i];
                                }

                            }

                            // Defining of variable responding for counting number of repetitions
                            // of the longest word in the text.
                            int numOfRepetition = 0;
                            foreach (string x in textByArrays)
                            {
                                if (x == maxLength)
                                {
                                    numOfRepetition++;
                                }
                            }

                            // Displaying the longest word and number of its repetitions.
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Your text — \n{usersInput}");
                            Console.WriteLine("\nThe longest word: {0}\nNumber of repetitions: {1}", maxLength, numOfRepetition);
                            break;

                            // Replacing numbers with their name in the form of text.
                        case 3:
                            usersInput = usersInput.Replace("0", "zero").Replace("1", "one").Replace("2", "two").Replace("3", "three").Replace("4", "four").Replace("5", "five").Replace("6", "six").Replace("7", "seven").Replace("8", "eight").Replace("9", "nine");
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Your text after replacing numbers with their names in the form of text: \n\n{usersInput}");
                            break;

                        case 4:
                            // Defining an array which is containing sentences using separators.
                            string[] textSplit = usersInput.Split('.', '!', '?');

                            foreach (string str in textSplit)
                            {
                                // Checking if there is '?' sign in the each sentence.
                                if (str.Contains('?') == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    string trimmedText = str.Trim();
                                    Console.WriteLine(trimmedText.Substring(0, trimmedText.IndexOf('?') + 1));
                                }
                            }
                            foreach (string str in textSplit)
                            {
                                // Checking if there is '!' sign in the each sentence.
                                if (str.Contains('!') == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    string trimmedText = str.Trim();
                                    Console.WriteLine(trimmedText.Substring(0, trimmedText.IndexOf('!') + 1));
                                }
                            }
                            Console.ReadKey();
                            break;

                            // Defining an array which contain sentences devided by the separators.
                        case 5:
                            string[] splitText = usersInput.Split('.', '!', '?');

                            // Looking over every sentence in the array.
                            foreach (string sentence in splitText)
                            {
                                // Checking if there's ',' sign in the sentence.
                                if (!sentence.Contains(','))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(sentence.Trim());
                                }
                            }
                            break;
                    }

                    // Menu responding for users choice to continue using application.
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tTo perform another operation on the current text type 1, \n\tTo input new text type 2, \n\tTo exit StringEditor type anything...");
                    Console.ForegroundColor = ConsoleColor.White;

                    // Variable containing users choice how to continue using application or quit.
                    string continuation = Console.ReadLine();
                    continuation = continuation.ToLower();
                    
                    // Performing an action depending on the user's choice.
                    switch (continuation)
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Your text: \n{usersInput}");
                            newInput = false;
                            repeatOperation = true;
                            break;
                        case "2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            newInput = true;
                            repeatOperation = false;
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}
