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
        Random rng;    
        public AI(Random rng)
        {
            rng = this.rng;
        }
        public override Gesture ChooseGesture()
        {

            return null;
        }
    }
}
