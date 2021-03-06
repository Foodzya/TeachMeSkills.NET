﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        // Define a variable to store the number of lines.
        static int lines;

        // Define a variable to store the number of columns.
        static int columns;

        // Define variables to store the number of positive / negative numbers.
        static int pos = 0;
        static int neg = 0;

        // Define of a boolean variable which responsible for the state of the application. 
        static bool flag = true;

        // Defining of a boolean variable which responsible  
        // for the selecting actions on an array and for
        // continuing working with application.
        static bool arrayActions = true;

        // Defining variable which contain menu of actions.
        static string actionMenu =
        "\nAction Menu" +
        "\n1. Finding the number of positive / negative numbers in a matrix" +
        "\n2. Sorting matrix elements line by line (in two directions)" +
        "\n3. Inverting matrix elements line by line";

        // Defining and assigment of an variable 
        // which contain the user-selected action on an array.
        static string action;

        // Variable that is responsible for the state 
        // of the loop where actions are performed on the array. 
        static bool ifAction = true;

        // Variable that is responsible for continuing
        // working with application or for exit
        static bool operationToContinue = true;

        // Variable which contain users choice about 
        // continuing working with application.
        static string decision;

        // Defining a two-dimensional array.
        static double[,] matrix = new double[0, 0];

        static void EnterMatrixComponents()
        {
            // Inputting of a number of lines.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nEnter the number of lines in the array: ");
            while (!int.TryParse(Console.ReadLine(), out lines) || lines <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\aWrong number. Try again.");
                Console.ForegroundColor = ConsoleColor.Green;
            }

            // Inputting of a number of columns.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the number of columns in the array: ");
            while (!int.TryParse(Console.ReadLine(), out columns) || columns <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\aWrong number. Try again.");
                Console.ForegroundColor = ConsoleColor.Green;
            }

        }

        static void FillingTheArray(int Length0, int Length1)
        {
            // Filling the array.
            for (int i = 0; i < Length0; i++)
            {
                for (int j = 0; j < Length1; j++)
                {
                    Console.Write("Enter element in {0} line and {1} column: ", i + 1, j + 1);
                    while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\aIncorrect number. Try again.");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                }
            }
        }

        static void MatrixAppearance()
        {
            Console.WriteLine("Here's your matrix!");
            Console.WriteLine("\n");
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                    Console.Write("\t" + matrix[y, x] + "  ");
                Console.WriteLine();
            }
        }

        static void ActionOnArrayChoice()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(actionMenu + "\n\nSelect the action you want to perform on the array: ");
            Console.ForegroundColor = ConsoleColor.Green;
            action = Console.ReadLine();
        }

        static void SwitchForUsersChoice()
        {
            if (action == "1" || action == "2" || action == "3")
            {
                switch (action)
                {
                    // Finding the number of positive and negative numbers.
                    case "1":
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i, j] > 0)
                                {
                                    pos++;
                                }
                                else if (matrix[i, j] < 0)
                                {
                                    neg++;
                                }
                            }
                        }
                        Console.WriteLine("Number of positive numbers is {0} \nNumber of negative numbers is {1}", pos, neg);

                        neg = 0;
                        pos = 0;

                        ifAction = false;
                        operationToContinue = true;
                        break;

                    // Sorting matrix elements line by line in descending and ascending order.
                    case "2":

                        // Defining of the variable responsible for choosing a sort method.
                        bool sorting = true;

                        // Loop responsible for sorting of an array in 2 ways.
                        while (sorting)
                        {
                            Console.Write("If you want to do ascending sort enter 1, if descending enter 2: ");

                            // Variable that contain the user-selected sorting method.
                            string sortSelect = Console.ReadLine();

                            // Ascending sort method of an array.
                            if (sortSelect == "1")
                            {
                                sorting = false;
                                for (int i = 0; i < lines; i++)
                                {
                                    for (int j = 0; j < columns; j++)
                                    {
                                        for (int k = 0; k < columns; k++)
                                        {
                                            if (matrix[i, j] <= matrix[i, k])
                                            {
                                                double temp = matrix[i, j];
                                                matrix[i, j] = matrix[i, k];
                                                matrix[i, k] = temp;
                                            }
                                        }
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine("\tYour matrix after ascending sort:");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                for (int i = 0; i < lines; i++)
                                {
                                    for (int j = 0; j < columns; j++)
                                    {
                                        Console.Write("\t" + matrix[i, j] + "  ");
                                    }
                                    Console.WriteLine();
                                }
                            }

                            // Descending sort method of an array.
                            else if (sortSelect == "2")
                            {
                                sorting = false;
                                for (int i = 0; i < lines; i++)
                                {
                                    for (int j = 0; j < columns; j++)
                                    {
                                        for (int k = 0; k < columns; k++)
                                        {
                                            if (matrix[i, j] >= matrix[i, k])
                                            {
                                                double temp = matrix[i, j];
                                                matrix[i, j] = matrix[i, k];
                                                matrix[i, k] = temp;
                                            }
                                        }
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine("\tYour matrix after descending sort:");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                for (int i = 0; i < lines; i++)
                                {
                                    for (int j = 0; j < columns; j++)
                                    {
                                        Console.Write("\t" + matrix[i, j] + "  ");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\aIncorrect input. Try again.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        ifAction = false;
                        operationToContinue = true;
                        break;

                    // Inversion of an array line by line.
                    case "3":
                        Console.Clear();
                        Console.WriteLine("\tYour matrix after inversion line by line:");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int y = 0; y < matrix.GetLength(0); y++)
                        {
                            for (int x = 0; x < matrix.GetLength(1); x++)
                            {
                                matrix[y, x] = -matrix[y, x];
                                Console.Write("\t" + matrix[y, x] + " ");
                            }
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        ifAction = false;
                        operationToContinue = true;
                        break;
                    default:
                        Console.WriteLine("Something goes wrong. Try again please...");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\aYou have entered non-existent action. Please try again: ");
                Console.ForegroundColor = ConsoleColor.Green;
                action = Console.ReadLine();
            }
        }

        static void DecisionToContinue()
        {
            Console.WriteLine("Do you want to perform another operation on entered array? (y/n)");
            decision = Console.ReadLine();
            decision = decision.ToLower();
            if (decision == "y" || decision == "n")
            {
                if (decision == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Your matrix looks like: ");
                    Console.WriteLine();
                    MatrixAppearance();
                    ifAction = true;
                    flag = false;
                    operationToContinue = false;
                }
                else if (decision == "n")
                {
                    string quitDecision;
                    Console.WriteLine("Do you want to enter another matrix? Enter Y to continue, enter anything to quit");
                    quitDecision = Console.ReadLine();
                    quitDecision = quitDecision.ToLower();
                    if (quitDecision == "y")
                    {
                        Console.Clear();
                        operationToContinue = false;
                        flag = true;
                        arrayActions = false;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        static void ApplicationPerformance()
        {
            // Print a greeting to the console.
            Console.WriteLine("Welcome to ArrayApp!");

            // Loop responsible for operation of the whole application.
            do
            {
                operationToContinue = true;
                arrayActions = true;
                ifAction = true;

                EnterMatrixComponents();

                matrix = new double[lines, columns];

                FillingTheArray(matrix.GetLength(0), matrix.GetLength(1));

                // Displaying of the entered array in the form of matrix.
                Console.Clear();
                MatrixAppearance();


                // Loop responsible for the selecting actions on an array 
                // and for continuing working with application.
                while (arrayActions)
                {
                    ActionOnArrayChoice();

                    // Loop for performing an action on a matrix.
                    while (ifAction)
                    {
                        SwitchForUsersChoice();
                    }

                    // Loop responsible for continuing working 
                    // with application or for exit.
                    while (operationToContinue)
                    {
                        DecisionToContinue();
                    }
                }
            }
            while (flag);
        }

        static void Main(string[] args)
        {
            ApplicationPerformance();
        }
    }
}