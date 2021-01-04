using System;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Greet();
            while (!game.DidWin() && !game.DidLose())
            {
                game.Display();
                game.Ask();
            }
            if (game.DidWin()) Console.WriteLine("You Win! Congratulations!");
            else Console.WriteLine("You lose. Better luck next time!");
        }
    }
}