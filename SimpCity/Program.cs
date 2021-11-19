using System;

namespace SimpCity {
    class Program {
        static void Main(string[] args) {
            ConsoleMenu menu = new ConsoleMenu()
                .BeforeInteraction(() => Console.WriteLine("Welcome, mayor of Simp City!\n" + new string('=', 26)))
                .AddOption("Start new game", (_cmd) => {
                    Game game = new Game();
                    game.Play();
                })
                .AddOption("Load saved game", (_cmd) => {
                    Game game = new Game();
                    game.Restore();
                    game.Play();
                })
                .AddHeading()
                .AddExitOption("Exit");

            menu.DisplayInteraction();

            // Don't close automatically
            Console.WriteLine("Until next time, mayor! Press any key to exit the program.");
            Console.ReadKey();
        }
    }
}
