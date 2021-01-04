using System;

namespace Spaceman
{
    class Game
    {
        public void Greet()
        {
            Console.WriteLine("Hello and welcome to \"Spaceman!\"");
            Console.WriteLine("Guess the letters in the word, each wrong guess will bring the spaceman closer to death!");
        }

        string codeWord, currentWord;
        int maxGuesses, wrongGuesses;
        string[] codeWords = new string[] { "alien", "earth", "saturn", "mars", "jupiter", "uranus", "mercury" };
        Ufo ufo = new Ufo();

        public Game()
        {
            codeWord = codeWords[new Random().Next(codeWords.Length)];
            maxGuesses = 5;
            wrongGuesses = 0;
            for (int i = 0; i < codeWord.Length; i++) currentWord += "_";
        }

        public bool DidWin()
        {
            return codeWord.Equals(currentWord);
        }

        public bool DidLose()
        {
            return wrongGuesses == maxGuesses;
        }

        public void Display()
        {
            Console.WriteLine(ufo.Stringify());
            Console.WriteLine(currentWord);
            Console.WriteLine("Number of guesses remaining: " + (maxGuesses - wrongGuesses));
        }

        public void Ask()
        {
            string input = "  ";
            while (input.Length != 1)
            {
                Console.WriteLine("Please only guess one letter at a time.");
                Console.WriteLine("Please guess a letter: ");
                input = Console.ReadLine();
            }
            if (codeWord.Contains(input))
            {
                Console.WriteLine("Correct!");
                int current = 0, index = 0;
                while (current < codeWord.Length && index > -1)
                {
                    index = codeWord.IndexOf(input, current, codeWord.Length - current);
                    if (index != -1)
                    {
                        currentWord = currentWord.Remove(index, 1).Insert(index, input);
                        current = index + 1;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect");
                wrongGuesses++;
                ufo.AddPart();
            }
        }
    }
}