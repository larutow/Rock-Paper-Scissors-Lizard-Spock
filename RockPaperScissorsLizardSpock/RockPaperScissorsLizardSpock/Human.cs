using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Human : Player
    {
        public override Gesture ChooseGesture()
        {
            Console.WriteLine("Enter Gesture Type: ");
            foreach (Gesture gesture in availableGestures)
            {
                Console.Write($"{gesture.gestureType} ");
            }
            Console.WriteLine("");
            EnterValidChoice();
            return null;
            // choose gesture codeblock
          
        }
        public void EnterValidChoice()
        {
            int validEntry = 1;
            string userEntry;
            do
            {
                userEntry = Console.ReadLine();
                for (int i = 0; i < availableGestures.Count; i++)
                {
                    validEntry = string.Compare(userEntry, availableGestures[i].gestureType, true);
                    if (validEntry == 0)
                    {
                        chosenGesture = availableGestures[i];
                        break;
                    }
                    Console.WriteLine("Invalid entry, please reenter string");
                }
            } while (validEntry != 0);

        }
    }
}
