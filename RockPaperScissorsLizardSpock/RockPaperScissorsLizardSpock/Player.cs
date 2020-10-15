using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Player
    {
        public Gesture gesture;
        //public string name;
        public int score;

        public Player()
        {

        }

        public virtual void ChooseGesture(List<Gesture> gestures)
        {
            // choose gesture codeblock
        }

        public virtual void ChooseGesture(List<Gesture> gestures, int indexOfChosenGesture)
        {
            // choose gesture codeblock
        }

        public void ScoreIncrease()
        {
            score++;
        }
    } 
}
