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
        string mode;
        public List<string> gameOptions;
        public bool p1AI;

        public Game()
        {
            bestOf = 3;
            rng = new Random();
            menuOptions = new List<string>{"1P Game", "2P Game", "Game Setup", "Rules / Help", "Exit Game" };
            mode = "RPSLS";
            gameOptions = new List<string>{"Toggle P1AI", "Toggle RPS Classic Mode"};
            p1AI = false;
        }

        public void PlayGame()
        {
            do
            {
                Console.Clear();
                p1.ChooseGesture();
                Console.Clear();
                p2.ChooseGesture();
                Console.Clear();
                ShowGestures();
                CompareGestures();
                ShowScores();
            }while (p1.score < (bestOf / 2) + 1 && p2.score < (bestOf / 2) +1);

            AnnounceVictor();
            EndGameOptions();
            
            //p1 choose
            //p2 choose
            //compare p1 choice & p2 choice (return winner)
            //(take in winner) score points
            //decide victor (best of 3)

        }

        public void EndGameOptions()
        {
            p1.score = 0;
            p2.score = 0;
            Console.WriteLine("Play again- enter 'y'? If 'n' or any other character: return to menu");
            char userInput = EndGameInput();
            switch (userInput)
            {
                case 'y':
                    PlayGame();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }

        public char EndGameInput()
        {
            char userInput = ' ';
            bool tryChar = false;
            do
            {
                tryChar = char.TryParse(Console.ReadLine(), out userInput);
                if (tryChar == false){
                    Console.WriteLine("Invalid Input - please re-enter");
                }
            } while (tryChar == false);
            return userInput;
        }
        public void AnnounceVictor()
        {
            if (p1.score > p2.score)
            {
                Console.WriteLine($"Game Over - P1 Wins: {p1.score} - {p2.score}");
            }
            else
            {
                Console.WriteLine($"Game Over - P2 Wins: {p2.score} - {p1.score}");
            }
        }

        public void ShowScores()
        {
            Console.WriteLine($"Scoreboard:\n{p1.name} - {p2.name}\n{p1.score} - {p2.score}\nEnter any key to continue.");
            Console.ReadLine();
        }
        
        public void ShowGestures()
        {
            Console.WriteLine("Press any key to show & compare both players selected gestures");
            Console.ReadLine();
            Console.WriteLine($"{p1.name} chose:{p1.chosenGesture.gestureType}\n{p2.name} chose:{p2.chosenGesture.gestureType}\n");
        }
        public void CompareGestures()
        { 
            if(p1.chosenGesture.gestureType == p2.chosenGesture.gestureType)
            {
                Console.WriteLine("Draw, no points scored");
                return;
            }
            if (p1.chosenGesture.gestureType == "rock")
            {
                if (p2.chosenGesture.gestureType == "scissors" || p2.chosenGesture.gestureType == "lizard")
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
                if (p2.chosenGesture.gestureType == "lizard" || p2.chosenGesture.gestureType == "paper")
                {
                    UpdateScore(p1);
                }
                else
                {
                    UpdateScore(p2);
                }
            }
            else if (p1.chosenGesture.gestureType == "lizard")
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
            Console.WriteLine($"{player.name} won the round");
            player.score++;
        }
        public void StartGame()
        {
            Console.WriteLine("Welcome to Rock - Paper - Lizard - Spock. Enter any key to continue.");
            Console.ReadLine();
            MainMenu();
        }

        public void DisplayMenu(List<String> menuoptions)
        {
            Console.WriteLine("Enter corresponding menu number");
            for (int i = 0; i < menuoptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {menuoptions[i]}");
            }
        }

        public void DisplayRules()
        {
        
            Console.WriteLine($"Rock Paper Scissors Lizard Spock is a gesture 'war' game where 2 competing players choose their gestures and based upon advantage a winner & loser or draw is determined.\n");
            
            Console.WriteLine($"This game has two primary modes:");
            Console.WriteLine($"1) 1P Mode - You as a human player will play against an AI who will choose their gesture at random");
            Console.WriteLine($"2) 2P Mode - You as a human player will play against another human, taking turns to pick your gestures\n");
            
            Console.WriteLine("The win conditions for each gesture is as follows:");
            Console.WriteLine("rock > scissors & lizard");
            Console.WriteLine("paper > rock & spock");
            Console.WriteLine("scissors > paper & lizard");
            Console.WriteLine("lizard > paper & spock");
            Console.WriteLine("spock > rock & scissors");
            Console.WriteLine("any gesture = itself (draw)\n");

            Console.WriteLine("Games are played in a \"bestof\" 3 fashion\n");

            Console.WriteLine("Game options include toggleable options for (1) 1P is an AI and (2) Rock Paper Scissors classic mode");

            Console.WriteLine("Press anykey to return to the main menu");
            Console.ReadLine();
            Console.Clear();
            MainMenu();
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

        public void GameOptions(int menuChoice)
        {
            //enable ai mode
            //enable rps classic

            switch (menuChoice)
            {
                case 1:
                    p1AI = !p1AI;
                    Console.WriteLine($"P1 is AI: {p1AI} - enter any key to continue");
                    Console.ReadLine();
                    MainMenu();
                    break;
                case 2:
                    if (mode == "RPSLS")
                    {
                        mode = "RPS";
                       
                    }
                    else
                    {
                        mode = "RPSLS";
                        
                    }
                    Console.WriteLine($"Mode Enabled: {mode} - enter any key to continue");
                    Console.ReadLine();
                    MainMenu();
                    break;
            }
        }

        public int MenuChoice(List<String> menuOptions)
        {
            int menuChoice;
            do
            {
                menuChoice = ChooseMenuOption();
                if (menuChoice < 1 || menuChoice > menuOptions.Count)
                {
                    Console.WriteLine($"Menu Option Out of Range (Please enter an int between 1 and {menuOptions.Count})");
                }
            } while (menuChoice < 1 || menuChoice > menuOptions.Count);
            return menuChoice;
        }

        public void PlayerSpawner(string name, Random rng, string mode, bool p1AI, int menuChoice)
        {

            if(name == "P1")
            {
                if (p1AI)
                {
                    if (mode == "RPSLS")
                    {
                        p1 = new AI("P1", rng);
                    }
                    else
                    {
                        p1 = new ClassicAI("P1", rng);
                    }

                }
                else
                {
                    if (mode == "RPSLS")
                    {
                        p1 = new Human("P1");
                    }
                    else
                    {
                        p1 = new ClassicHuman("P1");
                    }
                }
            }

            if (name == "P2")
            {
                if (mode == "RPSLS")
                {
                    if (menuChoice == 1)
                    {
                        p2 = new AI("P2", rng);
                    }
                    else if (menuChoice == 2)
                    {
                        p2 = new Human("P2");
                    }
                }
                else
                {
                    if (menuChoice == 1)
                    {
                        p2 = new ClassicAI("P2", rng);
                    }
                    else if (menuChoice == 2)
                    {
                        p2 = new ClassicHuman("P2");
                    }
                }
            }

        }
        public void MainMenu()
        {
            int menuChoice;
            int gameChoice;
            DisplayMenu(menuOptions);
            menuChoice = MenuChoice(menuOptions);
            switch (menuChoice)
            {
                case 1:
                    PlayerSpawner("P1", rng, mode, p1AI, menuChoice);
                    PlayerSpawner("P2",rng, mode, p1AI, menuChoice);
                    Console.Clear();
                    PlayGame();
                    break;
                case 2:
                    PlayerSpawner("P1", rng, mode, p1AI, menuChoice);
                    PlayerSpawner("P2", rng, mode, p1AI, menuChoice);
                    Console.Clear();
                    PlayGame();
                    break;
                case 3:
                    Console.Clear();
                    DisplayMenu(gameOptions);
                    gameChoice = MenuChoice(gameOptions);
                    GameOptions(gameChoice);
                    break;
                case 4:
                    Console.Clear();
                    DisplayRules();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

    }
}
