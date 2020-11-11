using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Greetings.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\tWelcome to Calculator");
            Console.WriteLine("\t\t\t---------------------");
            Console.ForegroundColor = ConsoleColor.Green;


            // Definition a variable which contain operation menu
            string menu = ("\nOperation menu: " +
                "\n1) Addition (+), " +
                "\n2) Subtraction (-), " +
                "\n3) Division (/), " +
                "\n4) Multiplication (*), " +
                "\n5) Percentage (%), " +
                "\n6) Square root (^)");

            // Variables which store the first and second numbers.
            double num1 = 0.0;
            double num2 = 0.0;

            // Variables responsible for the state of the program.
            bool condition = true;
            bool flag = true;

            // Array that store last 5 results.
            double[] last5Res = new double[5];
            int index = 0;

            // Loop responsible for the functioning of the full application
            while (flag)
            {
                // Loop that is responsible for operation sign input.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(menu);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n\nSelect the operation by entering its sign: ");
                char operation;

                // Loop checking for incorrect sign input.
                while (!char.TryParse(Console.ReadLine(), out operation))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\aWrong operation. Try again: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                //  Loop that is responsible for entering numbers by user without entering operation sign.
                do
                {
                    // Checks if a '^' sign has been entered.
                    if (operation == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter the number of which you want to calculate square root: ");
                        while (!double.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\aIt's not a number. Try again: ");
                            Console.ForegroundColor = ConsoleColor.Green;

                        }
                    }

                    // Block responsible for inputting numbers for operation.
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter first number: ");
                        while (!double.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\aIncorrect number. Try again: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter second number: ");
                        while (!double.TryParse(Console.ReadLine(), out num2))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\aIncorrect number. Try again: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;


                    // Checking for sign input, performing a math operation
                    // And writing the result to an array which store last 5 results.
                    switch (operation)
                    {
                        case '+':
                            double result = num1 + num2;
                            Console.WriteLine($"\t\n{num1} + {num2} = {result}");
                            
                            if (index == 5)
                            {
                                index = 0;
                                last5Res[index] = result;
                                index++;
                            }
                            else
                            {
                                last5Res[index] = result;
                                index++;
                            }
                            break;
                        case '-':
                            result = num1 - num2;
                            Console.WriteLine($"\t\n{num1} - {num2} = {result}");
                            if (index == 5)
                            {
                                index = 0;
                                last5Res[index] = result;
                                index++;
                            }
                            else
                            {
                                last5Res[index] = result;
                                index++;
                            }
                            break;
                        case '*':
                            result = num1 * num2;
                            Console.WriteLine($"\t\n{num1} * {num2} = {result}");
                            if (index == 5)
                            {
                                index = 0;
                                last5Res[index] = result;
                                index++;
                            }
                            else
                            {
                                last5Res[index] = result;
                                index++;
                            }
                            break;
                        case '/':
                            if (num2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\aYou cannot divide by zero!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            }
                            else
                            {
                                result = num1 / num2;
                                Console.WriteLine($"\t\n{num1} / {num2} = {result}");
                                if (index == 5)
                                {
                                    index = 0;
                                    last5Res[index] = result;
                                    index++;
                                }
                                else
                                {
                                    last5Res[index] = result;
                                    index++;
                                }
                                break;
                            }
                            
                        case '%':
                            result = (num1 / num2) * 100;
                            Console.WriteLine($"\t\n{num1} out of {num2} is {result}%");
                            if (index == 5)
                            {
                                index = 0;
                                last5Res[index] = result;
                                index++;
                            }
                            else
                            {
                                last5Res[index] = result;
                                index++;
                            }
                            break;
                        case '^':
                            result = Math.Sqrt(num1);
                            Console.WriteLine($"\nSquare root of {num1} is {result}");
                            if (index == 5)
                            {
                                index = 0;
                                last5Res[index] = result;
                                index++;
                            }
                            else
                            {
                                last5Res[index] = result;
                                index++;
                            }
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\aYou have entered incorrect operation sign. Try again.");
                            condition = false;
                            break;
                    }

                    // Variable defining the state of the menu.
                    bool menuCondition = true;

                    // Checks if the correct operators have been entered.
                    if (operation == '+' || operation == '-' || operation == '/' || operation == '*' || operation == '%' || operation == '^')
                    {
                        // Loop responsible for the state of the menu.
                        while (menuCondition == true)
                        {
                            menuCondition = true;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nTo quit calculator enter \"Q/q\". " +
                                "\nTo choose new operation enter \"menu\". " +
                                "\nTo repeat last operation w/o entering sign enter repeat" +
                                "\nTo display results of last 5 operations enter \"results\"" +
                                "\nTo select a new operation enter anything");

                            // Variable that is responsible for the decision to continue working with the application 
                            string decision = Console.ReadLine();
                            decision = decision.ToLower();
                            
                            // Exit the application.
                            if (decision == "q")
                            {
                                Environment.Exit(0);
                            }

                            // Back to menu to choose new operation.
                            else if (decision == "menu")
                            {
                                Console.Clear();
                                menuCondition = false;
                                condition = false;
                                flag = true;
                            }

                            // Show results of five last operations.
                            else if (decision == "results")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("Last 5 results are: ");
                                foreach (double item in last5Res)
                                {
                                    Console.Write(item + "\t");
                                }
                                Console.WriteLine();
                            }

                            // Repeat operation w/o entering operation sign.
                            else if (decision == "repeat")
                            {
                                Console.Clear();
                                Console.WriteLine("Your last entered operation is {0} ", operation);
                                menuCondition = false;
                                condition = true;
                                flag = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("\aUnknown command. Try again.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }     
                }
                while (condition == true);
            }
        }
    }
}