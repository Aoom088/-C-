using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int balance = 100;

            while (true)
            {
                Console.WriteLine("Account");
                Console.WriteLine("=======");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("0. Exit");
                Console.Write("Select number : ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int select))
                {
                    switch (select)
                    {
                        case 3:
                            Console.WriteLine($"\nAccount balance is: {balance}");
                            Console.Write("Press any key....");
                            Console.ReadLine();
                            break;
                        case 1:
                            Console.Write($"\nEnter money to deposit: ");
                            string depositMoney = Console.ReadLine();
                            balance += int.Parse(depositMoney);

                            Console.WriteLine($"Account balance is: {balance}");
                            Console.Write("Press any key....");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Write($"\nEnter money to withdraw: ");
                            string withdrawMoney = Console.ReadLine();
                            if(balance - int.Parse(withdrawMoney) < 100)
                            {
                                Console.WriteLine("Canont withdraw becourse money will less 100");
                            }
                            else
                            {
                                balance -= int.Parse(withdrawMoney);
                                Console.WriteLine($"Account balance is: {balance}");
                            }
                            Console.Write("Press any key....");
                            Console.ReadLine();
                            break;
                        case 0:
                            Console.WriteLine("Exiting program...");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nInvalid");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter '0 1 2 3'");
                }

                Console.WriteLine("\n");

            }
        }
    }
}
