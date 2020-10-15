using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Game
    {
        List<Gesture> gestures;
        List<string> menuOptions;
        Human p1;
        Player p2;
        Random rng;

        public Game()
        {
            p1 = new Human();
            menuOptions = new List<string>{"1P Game", "2P Game", "Rules / Help", "Exit Game"};
        }

        public void PlayGame()
        {

        }
        public void StartGame()
        {
            Console.WriteLine("Welcome P1 to Rock - Paper - Lizard - Spock. Enter any key to continue.");
            Console.ReadLine();
            MainMenu();
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu - Choose 1P, 2P Mode, or Quit by entering corresponding menu number");
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {menuOptions[i]}");
            }
        }

        public void DisplayRules()
        {

        }
        public void MainMenu()
        {
            int menuChoice;
            DisplayMainMenu();
            do
            {
                menuChoice = p1.ChooseMenuOption();
                if (menuChoice < 1 || menuChoice > menuOptions.Count)
                {
                    Console.WriteLine($"Menu Option Out of Range (Please enter an int between 1 and {menuOptions.Count})");
                }
            } while (menuChoice < 1 || menuChoice > menuOptions.Count);
            switch (menuChoice)
            {
                case 1:
                    p2 = new AI();
                    PlayGame();
                    break;
                case 2:
                    p2 = new Human();
                    PlayGame();
                    break;
                case 3:
                    DisplayRules();
                    break;
                case 4:
                    Console.WriteLine("Thanks for playing. Enter any key to exit");
                    Console.ReadLine();
                    break;
            }
        }

    }
}
