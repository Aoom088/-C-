using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HangmanService game = new HangmanService();
            game.Restart();
            
            while (true)
            {
                Console.WriteLine($"\n{game.GetDisplay()}");

                Console.Write("\nplease enter character: ");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    Output userInput = game.Input(input[0]);
                    switch (userInput)
                    {
                        case Output.Correct:
                            if (!(game.GetDisplay()).Contains("_"))
                            {
                                Console.WriteLine("Congratulation, you’re win.");
                                Console.WriteLine("Enter to restart....");
                                Console.ReadKey();
                                game.Restart();
                            }
                            break;
                        case Output.Incorrect:
                            Console.WriteLine("Sorry, you’re wrong.");
                            Console.WriteLine($"Remaining ….. {game.GetRemainingTry()}");
                            if (game.GetRemainingTry() == 0)
                            {
                                Console.WriteLine("It's time to reset.");
                                Console.WriteLine("Enter....");
                                Console.ReadKey();
                                game.Restart();
                            }
                            break;
                        case Output.Duplicate:
                            Console.WriteLine("you have already tried this character.");
                            break;
                    }
                }
                else
                {
                    game.Restart();
                }
            }
        }
    }

    enum Output
    {
        Correct = 0,
        Incorrect = 1,
        Duplicate = 2,
    }
    class HangmanService
    {
        string[] vocabulary = {
            "Advantageous","Consequence","Intellectual","Dramatization","Appreciation","Circumstance",
            "Considerable","Extraordinary","Environmentally","Misunderstanding"
        };
        char[] answer = {};
        List<char> entered = new List<char>();
        string randVocabulary = "";
        int remaining = 10;
        public void Restart()
        {
            entered.Clear();
            remaining = 10;
            Random rand = new Random();
            randVocabulary = (vocabulary[rand.Next(vocabulary.Length)]).ToLower();
            answer = randVocabulary.ToCharArray();
            for (int i = 0; i < randVocabulary.Length; i++)
            {
                answer[i] = '_';
            }
        }
        public string GetDisplay() 
        {
            return string.Join(" ", answer);
        }
        public Output Input(char character)
        {
            if (entered.Contains(character))
            {
                return Output.Duplicate;
            }
            else if (randVocabulary.Contains(character))
            {
                entered.Add(character);
                for (int i = 0; i < randVocabulary.Length; i++)
                {
                    if (character == randVocabulary[i])
                    {
                        answer[i] = randVocabulary[i];
                    }
                }
                return Output.Correct;
            }
            else
            {
                entered.Add(character);
                remaining -= 1;
                return Output.Incorrect;
            }
        }
        public int GetRemainingTry()
        {
            return remaining; 
        }
    }
}
