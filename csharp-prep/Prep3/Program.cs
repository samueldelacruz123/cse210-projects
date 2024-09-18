using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int userGuess;

        Console.Write("What is your guess? ");
        string userGuessAnswer = Console.ReadLine();
        userGuess = int.Parse(userGuessAnswer);

        while (userGuess != magicNumber)
        {
            if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            else if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }

            Console.Write("What is your guess? ");
            userGuessAnswer = Console.ReadLine();
            userGuess = int.Parse(userGuessAnswer);
        }

        Console.WriteLine("You guessed it!");
    }
}