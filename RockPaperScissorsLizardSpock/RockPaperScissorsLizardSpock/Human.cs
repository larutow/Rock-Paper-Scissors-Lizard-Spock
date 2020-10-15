using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Human : Player
    {
        public override void ChooseGesture(List<Gesture> gestures, int indexOfChosenGesture)
        {
            gesture = gestures[indexOfChosenGesture];
            // choose gesture codeblock
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
    }
}
