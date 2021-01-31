using System;
using Cola;
using Chips;
using Apple;
using Chick;
namespace HelloApp
{
    class Program
    {
        private enum Products
        {
            Crisps = 1,
            Cola,
            Chicken,
            Apples
        }

        private static double sumOfAllProducts = 0.0;

        private static bool flag = true;

        private static int UserInput()
        {
            Console.WriteLine($"Enter the number of product: \n 1 - {Products.Crisps}\n 2 - {Products.Cola}\n 3 - {Products.Chicken}\n 4 - {Products.Apples}");
            int userschoice = 0;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out userschoice))
                {
                    Console.WriteLine("Invalid number or number not listed...");
                }
                if (!(userschoice <= 4 & userschoice > 0))
                    Console.WriteLine("Number not listed. Try again..");
            }
            while (!(userschoice <= 4 & userschoice > 0));

            return userschoice;
        }

        public static void SetCocaCola()
        {
            Coca_Cola coca = new Coca_Cola(1, 15.5, 100, "Coca-cola");
            sumOfAllProducts += coca.Price;
            coca.GetInfo();
        }

        public static void SetCrisps()
        {
            Crisps crisps = new Crisps(2, 9.9, 1500, "Crisps");
            sumOfAllProducts += crisps.Price;
            crisps.GetInfo();
        }

        public static void SetChicken()
        {
            Chicken chicken = new Chicken(3, 15.9, 1300, "Chicken");
            sumOfAllProducts += chicken.Price;
            chicken.GetInfo();
        }

        public static void SetApples()
        {
            Apples apples = new Apples(3, 4.5, 5000, "Apple");
            sumOfAllProducts += apples.Price;
            apples.GetInfo();
        }

        private static void SwitchForProducts()
        {
            int userchoice = UserInput();

            switch (userchoice)
            {
                case (int)Products.Crisps:
                    SetCrisps();
                    break;
                case (int)Products.Cola:
                    SetCocaCola();
                    break;
                case (int)Products.Chicken:
                    SetChicken();
                    break;
                case (int)Products.Apples:
                    SetApples();
                    break;
                default:
                    Console.WriteLine("Unknown");
                    break;
            }
            ToCloseApp();
        }

        private static void SumOfAllProducts()
        {
            Console.Clear();
            Console.WriteLine($"Summary price of all products is {sumOfAllProducts}");
            Console.WriteLine("Type anything to continue...");
            Console.ReadKey();
        }

        private static void ToCloseApp()
        {
            int userschoice;
            Console.WriteLine("1 - exit application\n2 - choose another product\n3 - Display summary price of inventory");
            while (!int.TryParse(Console.ReadLine(), out userschoice))
            {
                Console.WriteLine("Invalid number or number not listed...");
            }
            if (!(userschoice <= 3 & userschoice > 0))
                Console.WriteLine("Number not listed. Try again..");
            switch (userschoice)
            {
                case 1:
                    Environment.Exit(0);
                    break;
                case 2:
                    break;
                case 3:
                    SumOfAllProducts();
                    break;
            }
            Console.Clear();
        }

        private static void SetForConsoleColors()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
        }


        static void Main(string[] args)
        {
            SetForConsoleColors();


            while (flag)
            {
                SwitchForProducts();
            }


            Console.ReadLine();
        }
    }
}

class Product
{
    public int Id { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public string Name { get; set; }

    public Product(int id, double price, int quantity, string name)
    {
        Id = id;
        Price = price;
        Quantity = quantity;
        Name = name;
    }
    public Product(double price)
    {
        Price = price;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Name is {Name}, \nID is {Id}, \nPrice is {Price}, \nQuantity is {Quantity}.");
    }
}