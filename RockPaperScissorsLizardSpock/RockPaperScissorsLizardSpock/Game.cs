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
        public List<string> menuOptions;
        public Player p1;
        public Player p2;
        public Random rng;
        public int bestOf;

        public Game()
        {
            bestOf = 3;
            rng = new Random();
            menuOptions = new List<string>{"1P Game", "2P Game", "Rules / Help", "Exit Game"};
        }

        public void PlayGame()
        {
            do
            {
                p1.ChooseGesture();
                p2.ChooseGesture();
                CompareGestures();

            }while (p1.score < (bestOf / 2) + 1 || p2.score < (bestOf / 2) +1);
            //p1 choose
            //p2 choose
            //compare p1 choice & p2 choice (return winner)
            //(take in winner) score points
            //decide victor (best of 3)

        }

        public void CompareGestures()
        {
            if(p1.chosenGesture == p2.chosenGesture)
            {
                Console.WriteLine("Draw, no points scored");
                return;
            }
            if (p1.chosenGesture.gestureType == "rock")
            {
                if (p2.chosenGesture.gestureType == "scissors" || p2.chosenGesture.gestureType == "lizzard")
                {
                    UpdateScore(p1);
                }
                else
                {
                    UpdateScore(p2);
                }
            }
            else if (p1.chosenGesture.gestureType == "paper")
            {
                if (p2.chosenGesture.gestureType == "rock" || p2.chosenGesture.gestureType == "spock")
                {
                    UpdateScore(p1);
                }
                else
                {
                    UpdateScore(p2);
                }
            }
            else if (p1.chosenGesture.gestureType == "scissors")
            {
                if (p2.chosenGesture.gestureType == "lizzard" || p2.chosenGesture.gestureType == "paper")
                {
                    UpdateScore(p1);
                }
                else
                {
                    UpdateScore(p2);
                }
            }
            else if (p1.chosenGesture.gestureType == "lizzard")
            {
                if (p2.chosenGesture.gestureType == "spock" || p2.chosenGesture.gestureType == "paper")
                {
                    UpdateScore(p1);
                }
                else
                {
                    UpdateScore(p2);
                }
            }
            else if (p1.chosenGesture.gestureType == "spock")
            {
                if (p2.chosenGesture.gestureType == "scissors" || p2.chosenGesture.gestureType == "rock")
                {
                    UpdateScore(p1);
                }
                else
                {
                    UpdateScore(p2);
                }
            }
        }

        public void UpdateScore(Player player)
        {
            player.score++;
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

        public int ChooseMenuOption()
        {
            bool isEntryInt = false;
            int menuChoice;
            do
            {
                isEntryInt = int.TryParse(Console.ReadLine(), out menuChoice);
                if (!isEntryInt)
                {
                    Console.WriteLine("Input is not a valid integer - please reenter");
                }
            } while (isEntryInt == false);
            return menuChoice;
        }

        public void MainMenu()
        {
            int menuChoice;
            DisplayMainMenu();
            do
            {
                menuChoice = ChooseMenuOption();
                if (menuChoice < 1 || menuChoice > menuOptions.Count)
                {
                    Console.WriteLine($"Menu Option Out of Range (Please enter an int between 1 and {menuOptions.Count})");
                }
            } while (menuChoice < 1 || menuChoice > menuOptions.Count);
            
            switch (menuChoice)
            {
                case 1:
                    p1 = new Human();
                    p2 = new AI(rng);
                    PlayGame();
                    break;
                case 2:
                    p1 = new Human();
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
