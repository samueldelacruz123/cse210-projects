using System;

class Program
{
    static void Main(string[] args)
    {
        Reference singleVerseReference = new Reference("John", 3, 16);
        Scripture singleVerseScripture = new Scripture(singleVerseReference, 
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life");

        Reference multiVerseReference = new Reference("Proverbs", 3, 5, 6);
        Scripture multiVerseScripture = new Scripture(multiVerseReference, 
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths");

        Console.Clear();
        Console.WriteLine(singleVerseScripture.GetDisplayText());
        
        while (!singleVerseScripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            singleVerseScripture.HideRandomWords(1);
            Console.Clear();
            Console.WriteLine(singleVerseScripture.GetDisplayText());
        }

        Console.WriteLine("All words for the single verse are hidden. Program will continue...");

        Console.Clear();
        Console.WriteLine(multiVerseScripture.GetDisplayText());
        
        while (!multiVerseScripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            multiVerseScripture.HideRandomWords(1);
            Console.Clear();
            Console.WriteLine(multiVerseScripture.GetDisplayText());
        }

        Console.WriteLine("All words for the multiple verses are hidden. Program has ended.");
    }
}
