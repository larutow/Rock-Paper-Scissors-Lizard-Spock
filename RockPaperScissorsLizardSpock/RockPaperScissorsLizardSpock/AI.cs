using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class AI : Player
    {
        public Random rng;    
        public AI(string name, Random rng)
            :base(name)
        {
            this.rng = rng;
        }
        public override Gesture ChooseGesture()
        {
            int gestureChoice = rng.Next(0, availableGestures.Count);
            chosenGesture = availableGestures[gestureChoice];
            return null;
        }
    }
}
