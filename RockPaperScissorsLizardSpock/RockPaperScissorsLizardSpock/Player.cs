using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    abstract class Player
    {
        public Gesture gesture;
        //public string name;
        public int score;
        public List<Gesture> availableGestures;

        public Player()
        {
            availableGestures = new List<Gesture> { new Gesture("rock"), new Gesture("paper"), new Gesture("scissors"), new Gesture("lizard"), new Gesture("spock")};
        }

        public virtual Gesture ChooseGesture()
        {
            // choose gesture codeblock
            return null;
        }

        public void ScoreIncrease()
        {
            score++;
        }
    } 
}
