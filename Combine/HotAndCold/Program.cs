using System;

namespace HotAndCold
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("If you would like to play CoinFlipper, Please select 1.");
            Console.WriteLine("1 - CoinFlipper");
            Console.WriteLine("2 - Hot And Cold");
            string str = Console.ReadLine();
            int num = 0;

            while (!int.TryParse(str, out num))
            {
                Console.WriteLine("You have entered an invalid entry\nPlease Try Again");
                Console.WriteLine("If you would like to play CoinFlipper, Please select 1.");
                Console.WriteLine("1 - CoinFlipper");
                Console.WriteLine("2 - Hot And Cold");
                str = Console.ReadLine();
            }

            if (num == 1)
            {
                CoinFlipper coin = new();
            } 
            else
            {
                Guessing game = new Guessing();

                Console.WriteLine("number guesser started:"); // greet the user

                int secretnum = game.GenerateSecretNumber();

                int usernum = 0;

                do
                {
                    usernum = game.GetUserNumber();

                    Console.WriteLine(game.PrintResult(secretnum, usernum));

                } while (secretnum != usernum);

                Console.WriteLine("thanks for playing!");
            }
        }
    }
}