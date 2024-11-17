using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_change
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> cash = new Dictionary<int, int>
        {
            { 1000, 0 },
            { 500, 0 },
            { 100, 0 },
            { 50, 0 },
            { 10, 0 },
            { 5, 0 },
            { 1, 0 }
        };

            int total = InitializeCash(cash);
            if (total == -1) return;

            while (true)
            {
                Console.Write("\nEnter amount to change: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                if (int.TryParse(input, out int amount))
                {
                    if (amount > total)
                    {
                        Console.WriteLine("\nUnable to change money due to insufficient funds.");
                    }
                    else
                    {
                        if (ChangeMoney(cash, amount))
                        {
                            total -= amount;
                        }
                        else
                        {
                            Console.WriteLine("\nUnable to change money due to lack of proper denominations.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nenter number or 'exit'.");
                }
            }
        }

        static int InitializeCash(Dictionary<int, int> cash)
        {
            Console.WriteLine("\nInitialize your cash:");
            int total = 0;

            foreach (var denomination in new List<int>(cash.Keys))
            {
                Console.Write($"Enter amount for {denomination} baht: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int count))
                {
                    cash[denomination] = count;
                    total += denomination * count;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    return InitializeCash(cash); 
                }
            }
            return total;
        }

        static bool ChangeMoney(Dictionary<int, int> cash, int amount)
        {
            Dictionary<int, int> changedCash = new Dictionary<int, int>();
            foreach (var denomination in cash.Keys)
                changedCash[denomination] = 0;

            foreach (var denomination in cash.Keys)
            {
                int needed = Math.Min(amount / denomination, cash[denomination]);
                if (needed > 0)
                {
                    amount -= needed * denomination;
                    changedCash[denomination] = needed;
                }
            }

            if (amount > 0) return false;

            foreach (var denomination in changedCash.Keys)
            {
                cash[denomination] -= changedCash[denomination];
            }

            foreach (var pair in changedCash)
            {
                if (pair.Key == 1)
                {
                    Console.WriteLine($"use baht coin:{pair.Value} remaining {cash[pair.Key]}");
                }
                else if (pair.Key == 10 | pair.Key == 5)
                {
                    Console.WriteLine($"use coin {pair.Key} baht:{pair.Value} remaining {cash[pair.Key]}");
                }
                else
                {
                    Console.WriteLine($"use bank {pair.Key} baht:{pair.Value} remaining {cash[pair.Key]}");
                }
            }
            return true;
        }  
    }
}
